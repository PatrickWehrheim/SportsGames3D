using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerControllerBase : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 8f;
    [SerializeField] protected float _rotateSpeed = 500f;

    public bool HasBall { get; set; }

    protected CharacterController _characterController;
    protected Vector3 _moveVal;
    protected Vector3 _playerVelocity;
    protected Transform _playerTransform;
    protected Ball _ball;
    protected float _shotStrength = 35000f;
    protected float _maxShootPower = 1.72f;
    protected BoxCollider _boxCollider;
    protected AudioSource _audioSource;
    protected float _colliderCooldown = 0;
    protected bool _isShooted = false;
    protected bool _isShooting = false;

    public bool IsControlledByPlayer { get; set; }

    /// <summary>
    /// Moves the player
    /// </summary>
    protected abstract void Move();

    /// <summary>
    /// Gets called if a move key is pressed
    /// </summary>
    /// <param name="context">Inputaction context</param>
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveVal = context.ReadValue<Vector3>();
    }

    /// <summary>
    /// Gets called if the shoot key is pressed
    /// </summary>
    /// <param name="context">Inputaction context</param>
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (_ball != null)
        {
            if (context.started && !GameManager.Instance.IsGamePaused)
            {
                _isShooting = true;
            
                StartCoroutine(nameof(SetShootPowerHome));
            }

            if (context.canceled && !GameManager.Instance.IsGamePaused)
            {
                _isShooting = false;
                _playerTransform = gameObject.transform;
                float duration;
                if((float)context.duration > _maxShootPower)
                {
                    duration = _maxShootPower;
                }
                else
                {
                    duration = (float)context.duration;
                }
                _audioSource.Play();
                Shoot(duration);
                _ball.StickToPlayer(_characterController, false);
                HasBall = false;
                _ball = null;
            }
        }
    }

    /// <summary>
    /// Shoots the ball in the player direction
    /// </summary>
    /// <param name="duration">Multiplier for the shoot strength</param>
    public void Shoot(float duration)
    {
        if (_ball != null)
        {
            _boxCollider.enabled = false;
            _ball.RigidBody.velocity = Vector3.zero;
            _ball.RigidBody.AddForce(duration * _shotStrength * transform.right);
            _ball.StickToPlayer(null, false);
            _isShooted = true;
            UIManager.Instance.ResetShootPowerHome();
            UIManager.Instance.ResetShootPowerAway();
        }
    }

    /// <summary>
    /// While the shootkey is pressed, increase the shootpower
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator SetShootPowerHome()
    {
        int value = 0;
        while (_isShooting)
        {
            value++;
            UIManager.Instance.SetShootPowerHome(value);
            yield return value;
        }
    }
}
