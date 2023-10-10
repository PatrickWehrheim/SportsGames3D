

using System.Diagnostics;

public class CheckHasBall : Node
{
    private AIController _aIController;

    /// <summary>
    /// Constructor to set the ai controller
    /// </summary>
    /// <param name="aIController">Controller to set</param>
    public CheckHasBall(AIController aIController) : base()
    {
        _aIController = aIController;
    }

    /// <summary>
    /// Check if the player has the ball
    /// </summary>
    /// <returns>NodeState: State of the node</returns>
    public override NodeState Evaluate()
    {
        object ball = GetData("BallGameObject");
        if (ball != null && _aIController.HasBall)
        {
            _state = NodeState.Success;
            return _state;
        }

        return base.Evaluate();
    }
}
