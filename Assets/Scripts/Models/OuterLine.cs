using UnityEngine;

public class OuterLine : MonoBehaviour
{
    [SerializeField] private Orientation _orientation;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            bool isFromHomeTeam = other.GetComponent<Ball>().IsLastTouchedByHomeTeam;
            switch (_orientation)
            {
                case Orientation.North:
                    GameManager.Instance.OnBallOutAtSideLine(other.transform.position, isFromHomeTeam);
                    break;
                case Orientation.South:
                    GameManager.Instance.OnBallOutAtSideLine(other.transform.position, isFromHomeTeam);
                    break;
                case Orientation.West:
                    GameManager.Instance.OnBallOutAtGoalLine(TeamOrigin.Home);
                    break;
                case Orientation.East:
                    GameManager.Instance.OnBallOutAtGoalLine(TeamOrigin.Away);
                    break;
            }
        }
    }
}
