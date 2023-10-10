using UnityEngine;

public class GoalBase : MonoBehaviour
{
    [SerializeField] private TeamOrigin _teamOrigin; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.AddScore(_teamOrigin);
            GameManager.Instance.OnGoal();
        }    
    }
}
