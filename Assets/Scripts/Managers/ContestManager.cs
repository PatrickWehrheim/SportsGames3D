using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContestManager : MonoBehaviour
{
    public List<Contest> Contests = new List<Contest>();
    public bool ContestsLoaded = false;

    private int _teamSize = 11;

    public static ContestManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitContests();
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// Build the contests together with teams and players
    /// </summary>
    private void InitContests()
    {
        Contest league = new Contest("League");

        Team hanover = Teams.Hanover;
        Team hamburg = Teams.Hamburg;
        Team bremen = Teams.Bremen;
        Team bayern = Teams.Bayern;
        Team frankfurt = Teams.Frankfurt;

        Add11PlayersToTeam(hanover);
        Add11PlayersToTeam(hamburg);
        Add11PlayersToTeam(bremen);
        Add11PlayersToTeam(bayern);
        Add11PlayersToTeam(frankfurt);

        league.AddNewTeam(hanover);
        league.AddNewTeam(hamburg);
        league.AddNewTeam(bremen);
        league.AddNewTeam(bayern);
        league.AddNewTeam(frankfurt);
        
        Contests.Add(league);
        ContestsLoaded = true;
    }

    /// <summary>
    /// Adds 11 players to the team
    /// </summary>
    /// <param name="team">The team were to add players</param>
    private void Add11PlayersToTeam(Team team)
    {
        for (int i = 0; i < _teamSize; i++)
        {
            PlayerBase player;
            switch (team.Name)
            {
                case "Hannover":
                    //Position is allways GK (Goalkeeper) because the players are random for now
                    player = new PlayerBase(PlayerNames.GetRandomHanoverName(), Position.GK, Random.Range(80, 101));
                    break;
                case "Hamburg":
                    player = new PlayerBase(PlayerNames.GetRandomHamburgName(), Position.GK, Random.Range(80, 101));
                    break;
                case "Bremen":
                    player = new PlayerBase(PlayerNames.GetRandomBremenName(), Position.GK, Random.Range(80, 101));
                    break;
                case "Bayern":
                    player = new PlayerBase(PlayerNames.GetRandomBayernName(), Position.GK, Random.Range(80, 101));
                    break;
                case "Frankfurt":
                    player = new PlayerBase(PlayerNames.GetRandomFrankfurtName(), Position.GK, Random.Range(80, 101));
                    break;
                default:
                    player = new PlayerBase(PlayerNames.GetRandomHanoverName(), Position.GK, Random.Range(80, 101));
                    break;
            }
            
            team.Players.Add(player);
        }
    }
}
