

using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name { get; set; }
    public Position Position { get; set; }
    public TeamOrigin TeamOrigin { get; set; }
    public int Stamina { get; set; }

    /// <summary>
    /// Constructor to set the name, position and stamina to the player
    /// </summary>
    /// <param name="name">Name of the player</param>
    /// <param name="position">Position of the player</param>
    /// <param name="stamina">Stamina of the player</param>
    public Player(string name, Position position, int stamina)
    {
        Name = name;
        Position = position;
        Stamina = stamina;
    }
}
