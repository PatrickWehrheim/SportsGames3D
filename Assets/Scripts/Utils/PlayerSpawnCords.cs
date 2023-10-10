using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSpawnCords
{
    public static Formation Formation = Formation.F442;

    /// <summary>
    /// Returns the Coordinates for the home team for the given formation 
    /// </summary>
    /// <returns>Vector2[]</returns>
    public static Vector2[] GetPlayerHomeCords()
    {
        Vector2[] homeCords = new Vector2[11];
        switch (Formation)
        {
            case Formation.F442:
                homeCords[0] = new Vector2(-80.53f, 0f);
                homeCords[1] = new Vector2(-58.49f, 11.11f);
                homeCords[2] = new Vector2(-58.59f, 40.47f);
                homeCords[3] = new Vector2(-58.49f, -11.11f);
                homeCords[4] = new Vector2(-58.59f, -40.47f);
                homeCords[5] = new Vector2(-32.6f, 40.47f);
                homeCords[6] = new Vector2(-32.6f, 11.11f);
                homeCords[7] = new Vector2(-32.6f, -40.47f);
                homeCords[8] = new Vector2(-32.6f, -11.11f);
                homeCords[9] = new Vector2(-9.8f, 11.11f);
                homeCords[10] = new Vector2(-9.8f, -11.11f);
                break;
        }
        return homeCords;
    }

    /// <summary>
    /// Returns the Coordinates for the away team for the given formation 
    /// </summary>
    /// <returns>Vector2[]</returns>
    public static Vector2[] GetPlayerAwayCords()
    {
        Vector2[] homeCords = new Vector2[11];
        switch (Formation)
        {
            case Formation.F442:
                homeCords[0] = new Vector2(80.53f, 0f);
                homeCords[1] = new Vector2(58.49f, 11.11f);
                homeCords[2] = new Vector2(58.59f, 40.47f);
                homeCords[3] = new Vector2(58.49f, -11.11f);
                homeCords[4] = new Vector2(58.59f, -40.47f);
                homeCords[5] = new Vector2(32.6f, 40.47f);
                homeCords[6] = new Vector2(32.6f, 11.11f);
                homeCords[7] = new Vector2(32.6f, -40.47f);
                homeCords[8] = new Vector2(32.6f, -11.11f);
                homeCords[9] = new Vector2(9.8f, 11.11f);
                homeCords[10] = new Vector2(9.8f, -11.11f);
                break;
        }
        return homeCords;
    }
}
