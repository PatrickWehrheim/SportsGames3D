using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Contest
{
    public string Name { get; private set; }
    public List<(Team, int)> Standing = new List<(Team, int)>(); //Tuple with Team and Points
    public List<Game> Games = new List<Game>();

    public Contest(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Add the given team to the contest
    /// </summary>
    /// <param name="team">Team to add</param>
    public void AddNewTeam(Team team)
    {
        Standing.Add((team, 0));
    }

    /// <summary>
    /// Get all teams in the contest
    /// </summary>
    /// <returns>List of all teams</returns>
    public List<Team> GetAllTeams()
    {
        List<Team> teams = new List<Team>();
        foreach ((Team, int) team in Standing)
        {
            teams.Add(team.Item1);
        }
        return teams;
    }
}
