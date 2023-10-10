using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskDoNothingForRespawn : Node
{
    /// <summary>
    /// Do nothing to get a save respawn
    /// </summary>
    /// <returns>NodeState: State of the node</returns>
    public override NodeState Evaluate()
    {
        _state = NodeState.Running;
        return _state;
    }
}
