using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TaskShoot : Node
{
    private AIController _aIController;

    /// <summary>
    /// Constructor to set the ai controller
    /// </summary>
    /// <param name="aIController">Controller to set</param>
    public TaskShoot(AIController aIController) : base()
    {
        _aIController = aIController;
    }

    /// <summary>
    /// The player rotates to the opponent goal and shoot in the direction
    /// </summary>
    /// <returns>NodeState: State of the node</returns>
    public override NodeState Evaluate()
    {
        _aIController.GetController().transform.LookAt(_aIController.GetGoalTransform());
        _aIController.GetController().transform.Rotate(new Vector3(0, -90, 0));

        _aIController.Shoot(1);
        
        _state = NodeState.Running;
        return _state;
    }
}
