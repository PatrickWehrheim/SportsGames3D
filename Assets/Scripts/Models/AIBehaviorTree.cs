using System.Collections.Generic;
using UnityEngine;

public class AIBehaviourTree : BehaviorTreeBase
{
    private float _moveSpeed = 8f;
    private float _fovRange = 15f;

    private Transform _transform;
    private AIController _controller;

    public AIBehaviourTree(Transform transform, AIController controller) : base()
    {
        _transform = transform;
        _controller = controller;
    }

    /// <summary>
    /// Setup the behaviour tree
    /// </summary>
    /// <returns>The root node of the tree</returns>
    public override Node SetupTree()
    {
        Node root = new Selector(new List<Node>()
        {
            new Sequenzer(new List<Node>
            {
                new CheckRespawnNeeded(),
                new TaskDoNothingForRespawn()
            }),
            new Sequenzer(new List<Node>
            {
                new CheckHasBall(_controller),
                new TaskShoot(_controller),
            }),
            new Sequenzer(new List<Node>
            {
                new CheckBallInFOVRange(_transform, _fovRange),
                new TaskGoToBall(_controller, _transform, _moveSpeed),
                new TaskDoNothingForRespawn()
            }),
            new TaskIdle(_controller, _moveSpeed)
        });

        return root;
    }
}
