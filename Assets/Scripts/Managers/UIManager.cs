using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameData GameData;

    private ShootPower[] _shootPowers;

    private Stamina[] _staminas;

    private ScoreHome _scoreHome;
    private ScoreAway _scoreAway;
    private TeamHome _teamHome;
    private TeamAway _teamAway;

    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        _scoreHome = GetComponentInChildren<ScoreHome>();
        _scoreAway = GetComponentInChildren<ScoreAway>();
        _teamHome = GetComponentInChildren<TeamHome>();
        _teamAway = GetComponentInChildren<TeamAway>();
        _shootPowers = GetComponentsInChildren<ShootPower>();
    }

    /// <summary>
    /// Hide the UI
    /// </summary>
    public void HideUI()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Show the UI
    /// </summary>
    public void ShowUI()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Add a goal to the home team
    /// </summary>
    public void AddHomeGoal()
    {
        GameData.GoalsHome++;
        _scoreHome.UpdateScore();
    }

    /// <summary>
    /// Add a goal to the away team
    /// </summary>
    public void AddAwayGoal()
    {
        GameData.GoalsAway++;
        _scoreAway.UpdateScore();
    }

    /// <summary>
    /// Sets the home team name
    /// </summary>
    /// <param name="homeName">Name to set</param>
    public void SetHomeName(string homeName)
    {
        GameData.HomeTeamName = homeName;
        _teamHome.SetName();
    }

    /// <summary>
    /// Sets the away team name
    /// </summary>
    /// <param name="awayName">Name to set</param>
    public void SetAwayName(string awayName)
    {
        GameData.AwayTeamName = awayName;
        _teamAway.SetName();
    }

    /// <summary>
    /// Sets the shootpower on the UI for the home team
    /// </summary>
    /// <param name="value">value to set</param>
    public void SetShootPowerHome(int value)
    {
        _shootPowers[0].GetComponent<Slider>().value = value;
    }

    /// <summary>
    /// Reset the shootpower from the home team to zero
    /// </summary>
    public void ResetShootPowerHome()
    {
        _shootPowers[0].GetComponent<Slider>().value = 0;
    }

    /// <summary>
    /// Sets the shootpower on the UI for the away team
    /// </summary>
    /// <param name="value">value to set</param>
    public void SetShootPowerAway(int value)
    {
        _shootPowers[1].GetComponent<Slider>().value = value;
    }

    /// <summary>
    /// Reset the shootpower from the away team to zero
    /// </summary>
    public void ResetShootPowerAway()
    {
        _shootPowers[1].GetComponent<Slider>().value = 0;
    }
}
