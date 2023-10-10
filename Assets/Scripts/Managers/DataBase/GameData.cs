using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData")]
public class GameData : ScriptableObject
{
    public string HomeTeamName;
    public int GoalsHome;
    public string AwayTeamName;
    public int GoalsAway;
}

