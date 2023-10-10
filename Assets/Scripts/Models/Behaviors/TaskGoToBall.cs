
using UnityEngine;

public class TaskGoToBall : Node
{
    private AIController _controller;
    private Transform _transform;
    private float _moveSpeed;

    /// <summary>
    /// Constructor to set the controller, the transform and the move speed
    /// </summary>
    /// <param name="controller">Controller to set</param>
    /// <param name="transform">Transform of the current player</param>
    /// <param name="moveSpeed">Move speed to set</param>
    public TaskGoToBall(AIController controller, Transform transform, float moveSpeed) : base()
    {
        _controller = controller;
        _transform = transform;
        _moveSpeed = moveSpeed;
    }

    /// <summary>
    /// Move to the ball
    /// </summary>
    /// <returns>NodeState: State of the node</returns>
    public override NodeState Evaluate()
    {
        GameObject ballGameObject = (GameObject)GetData("BallGameObject");

        Vector3 lookPosition = new Vector3(ballGameObject.transform.position.x, 1f, ballGameObject.transform.position.z);
        _controller.GetController().transform.LookAt(lookPosition);
        _controller.GetController().transform.Rotate(new Vector3(0, -90, 0));
        Vector3 move = new Vector3(_moveSpeed, -1f, 0);
        _controller.GetController().Move(_transform.TransformDirection(move) * Time.deltaTime);

        _state = NodeState.Running;
        return _state;
    }
}
