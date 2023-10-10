using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    public string Name { get; private set; }
    public List<PlayerBase> Players { get; private set; }
    public Formation Formation { get; private set; }

    /// <summary>
    /// Constructor to set the teamname, initialise the playerlist and set the default formation
    /// </summary>
    /// <param name="name">The teamname</param>
    public Team(string name)
    {
        Name = name;
        Players = new List<PlayerBase>();
        Formation = Formation.F442;
    }
}
