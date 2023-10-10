using UnityEngine;

public class CheckBallInFOVRange : Node
{
    private Transform _transform;
    private float _fovRange;
    private int _ballLayerMask = 1<<6;

    /// <summary>
    /// Constructor to set the transform and the FOV range
    /// </summary>
    /// <param name="transform">Transform of the player</param>
    /// <param name="fovRange">FOV range</param>
    public CheckBallInFOVRange(Transform transform, float fovRange)
    {
        _transform = transform;
        _fovRange = fovRange;
    }

    /// <summary>
    /// Check if the ball is in FOV range
    /// And save the ball in the root node if a ball is found
    /// </summary>
    /// <returns>NodeState: State of the node</returns>
    public override NodeState Evaluate()
    {
        object ball = GetData("BallGameObject");
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _fovRange, _ballLayerMask);
        if (ball == null)
        {
            if (colliders.Length > 0)
            {
                GetRoot().SetData("BallGameObject", colliders[0].gameObject);
                _state = NodeState.Success;
                return _state;
            }

            return base.Evaluate();
        }
        else if (colliders.Length > 0)
        {
            _state = NodeState.Success;
            return _state;
        }
        else
        {
            ClearData("BallGameObject");
        }

        return base.Evaluate();
    }
}

