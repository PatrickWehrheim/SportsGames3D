using UnityEngine;

public class PlayerController : PlayerControllerBase
{
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _boxCollider = GetComponent<BoxCollider>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (GameManager.Instance.IsGamePaused || GameManager.Instance.RespawnNeeded)
        {
            return;
        }

        Move();
        if (_isShooted)
        {
            StartCoroutine(nameof(EnableBoxCollider));
        }
    }

    /// <summary>
    /// If the player is controlled,
    /// move over the characterController
    /// </summary>
    protected override void Move()
    {
        if (IsControlledByPlayer)
        {
            Vector3 move = new Vector3(_moveVal.z * _moveSpeed, Physics.gravity.y, 0);
            Vector2 rotate = new Vector2(0, _moveVal.x * _rotateSpeed);
            _characterController.Move(transform.TransformDirection(move) * Time.deltaTime);
            _characterController.transform.Rotate(rotate * Time.deltaTime);
        }
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
