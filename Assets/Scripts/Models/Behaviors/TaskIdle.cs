
using UnityEngine;

public class TaskIdle : Node
{
    private AIController _controller;
    private float _moveSpeed;

    private Vector3 _startPoint;
    private Vector3 _maxDistance = new Vector3(20f, 0, 0);

    /// <summary>
    /// Constructor to set the ai controller and the move speed
    /// </summary>
    /// <param name="aIController">Controller to set</param>
    /// <param name="moveSpeed">Move speed to set</param>
    public TaskIdle(AIController aIController, float moveSpeed)
        : base()
    {
        _controller = aIController;
        _moveSpeed = moveSpeed;
        _startPoint = new Vector3(_controller.gameObject.transform.position.x, 
            _controller.gameObject.transform.position.y, _controller.gameObject.transform.position.z);
    }

    /// <summary>
    /// Move the player back in the formation
    /// If team has the ball, go a bit forward
    /// </summary>
    /// <returns>NodeState: State of the node</returns>
    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(_controller.gameObject.transform.position, _startPoint);
        if ((GameManager.Instance.Ball.GetComponent<Ball>().IsLastTouchedByHomeTeam && distance > 0) || distance > _maxDistance.x )
        {
            _controller.gameObject.transform.Rotate(new Vector3(0, -90f, 0));
            _controller.GetController().transform.position = Vector3.MoveTowards(_controller.gameObject.transform.position, _startPoint, _moveSpeed * Time.deltaTime);
        }
        else if (distance < _maxDistance.x)
        {
            _controller.gameObject.transform.Rotate(new Vector3(0, 90f, 0));
            _controller.GetController().transform.position = Vector3.MoveTowards(_controller.gameObject.transform.position, _startPoint - _maxDistance, _moveSpeed * Time.deltaTime);
        }
        _controller.gameObject.transform.LookAt(GameManager.Instance.Ball.transform);
        
        _state = NodeState.Running;
        return _state;
    }
}
