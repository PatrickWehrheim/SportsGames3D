
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _ballTransform;
    private float _minX = -60.5f;
    private float _maxX = 60.5f;

    private void Update()
    {
        if (IsInBoundries())
        {
            transform.position = new Vector3(_ballTransform.position.x, transform.position.y, transform.position.z);
        }
    }

    /// <summary>
    /// Check if the ball is in the boundries of the camera position
    /// </summary>
    /// <returns>true: If the ball is inside</returns>
    private bool IsInBoundries()
    {
        if (_ballTransform.position.x > _minX && _ballTransform.position.x < _maxX)
        {
            return true;
        }

        return false;
    }
}