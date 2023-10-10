using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AnimationCurve movement;
    [SerializeField] float speedMultiplier = 0.4f;
    public bool IsLastTouchedByHomeTeam = false;

    private bool _isSticked = false;
    private bool _isPaused = false;
    private CharacterController _playerCC;
    private Vector3 _currentVelocity = Vector3.zero;


    private Rigidbody _rigidBody;
    public Rigidbody RigidBody { get { return _rigidBody; } private set { _rigidBody = value; } }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.IsGamePaused)
        {
            if (!_isPaused)
            {
                _currentVelocity = _rigidBody.velocity;
                _isPaused = true;
            }
            _rigidBody.velocity = Vector3.zero;
            return;
        }
        else
        {
            if(_isPaused)
            {
                _rigidBody.velocity = _currentVelocity;
                _currentVelocity = Vector3.zero;
                _isPaused = false;
            }
        }

        if (_isSticked)
        {
            
            Vector3 position = _playerCC.transform.position + _playerCC.transform.right * 1.2f;
            position.y = _rigidBody.position.y;
            _rigidBody.position = position;
            _rigidBody.velocity = _playerCC.velocity;
        }
        else
        {
            _rigidBody.velocity = new Vector3(
                _rigidBody.velocity.x * movement.Evaluate(Mathf.Abs(_rigidBody.velocity.x) * speedMultiplier),
                _rigidBody.velocity.y * movement.Evaluate(Mathf.Abs(_rigidBody.velocity.y) * speedMultiplier),
                _rigidBody.velocity.z * movement.Evaluate(Mathf.Abs(_rigidBody.velocity.z) * speedMultiplier)
            );
        }
    }

    /// <summary>
    /// "Stick" the ball to the given character controller
    /// </summary>
    /// <param name="characterController">The character controller to stick</param>
    /// <param name="isSticked">true: Stick the ball
    /// false: Set the sticked character controller to null and let the ball free</param>
    public void StickToPlayer(CharacterController characterController, bool isSticked)
    {
        _isSticked = isSticked;
        if (isSticked)
        {
            _playerCC = characterController;
            if (_playerCC.gameObject.GetComponent<Player>().TeamOrigin == TeamOrigin.Home)
            {
                IsLastTouchedByHomeTeam = true;
            }
            else
            {
                IsLastTouchedByHomeTeam = false;
            }
        }
        else
        {
            _playerCC = null;
        }
    }
}
