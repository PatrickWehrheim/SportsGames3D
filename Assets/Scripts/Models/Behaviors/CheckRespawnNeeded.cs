
public class CheckRespawnNeeded : Node
{
    /// <summary>
    /// Check if a respawn is needed
    /// </summary>
    /// <returns>NodeState: State of the node</returns>
    public override NodeState Evaluate()
    {
        if (GameManager.Instance.RespawnNeeded)
        {
            _state = NodeState.Success;
            return _state;
        }

        return base.Evaluate();
    }
}
