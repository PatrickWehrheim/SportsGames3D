using Google.Protobuf.WellKnownTypes;
using System;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public bool HasBall { get; set; }

    private Ball _ball;
    private float _shotStrength = 35000f;
    private float _maxShootPower = 1.72f;
    private CharacterController _characterController;
    private BoxCollider _boxCollider;
    private AudioSource _audioSource;
    private float _colliderCooldown = 0;
    private AIBehaviourTree _behaviourTree;
    private Transform _ballTransform;
    private Transform _goalTransform;
    private bool _isShooted;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        _ball = GameManager.Instance.Ball.GetComponent<Ball>();
        _goalTransform = GameManager.Instance.HomeGoal.transform;
        _ballTransform = GameManager.Instance.Ball.transform;

        _behaviourTree = new AIBehaviourTree(gameObject.transform, this);
        _behaviourTree.Start();
    }

    private void Update()
    {
        if (GameManager.Instance.IsGamePaused)
        {
            return;
        }
        _behaviourTree.Update();
        if (_isShooted)
        {
            StartCoroutine(nameof(EnableBoxCollider));
        }
    }

    /// <summary>
    /// Set the shootpower at the ui
    /// </summary>
    private void SetShootPowerAway()
    {
        int value = 100;
        UIManager.Instance.SetShootPowerAway(value);
    }

    /// <summary>
    /// Get the charachterController of the player
    /// </summary>
    /// <returns>CharacterController</returns>
    public CharacterController GetController()
    {
        return _characterController;
    }

    /// <summary>
    /// Gets the transform of the opponent goal
    /// </summary>
    /// <returns>Transform</returns>
    public Transform GetGoalTransform()
    {
        return _goalTransform;
    }

    /// <summary>
    /// Initiate a shoot of the ball
    /// </summary>
    /// <param name="duration">The duration of holding the key input</param>
    public void Shoot(float duration)
    {
        _boxCollider.enabled = false;
        _ball.RigidBody.velocity = Vector3.zero;
        _ball.RigidBody.AddForce(duration * _shotStrength * transform.right);
        _ball.StickToPlayer(null, false);
        _isShooted = true;
        HasBall = false;
        UIManager.Instance.ResetShootPowerAway();
    }

    /// <summary>
    /// Set the shootpower on ui,
    /// Play the shoot sound,
    /// shoot the ball
    /// </summary>
    public void ShootBall()
    {
        SetShootPowerAway();
        _audioSource.Play();
        Shoot(_maxShootPower);
    }

    /// <summary>
    /// After disabeling the collider,
    /// reenable it after 0.5 seconds
    /// </summary>
    private void EnableBoxCollider()
    {
        if (_colliderCooldown < 0.5f)
        {
            _colliderCooldown += Time.deltaTime;
        }
        else
        {
            _isShooted = false;
            HasBall = false;
            _boxCollider.enabled = true;
            _colliderCooldown = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            _ball = ball;
            ball.StickToPlayer(_characterController, true);
            HasBall = true;
        }
    }
}
