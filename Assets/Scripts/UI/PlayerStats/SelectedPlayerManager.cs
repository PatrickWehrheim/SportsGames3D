using UnityEngine;

public class SelectedPlayerManager : MonoBehaviour
{
    [SerializeField] private TeamOrigin _teamOrigin;
    private PlayerName _playerName;
    private Stamina _stamina;
    private ShootPower _shootPower;

    private void Awake()
    {
        _playerName = GetComponentInChildren<PlayerName>();
        _stamina = GetComponentInChildren<Stamina>();
        _shootPower = GetComponentInChildren<ShootPower>();
    }

    /// <summary>
    /// Change the UI to the current player
    /// </summary>
    /// <param name="origin">From which team is the player</param>
    /// <param name="name">Name of the player</param>
    /// <param name="stamina">Stamina value of the player</param>
    public void ChangePlayer(TeamOrigin origin, string name, int stamina)
    {
        if (_playerName == null)
        {
            _playerName = GetComponentInChildren<PlayerName>();
            
        }

        if (_stamina == null)
        {
            _stamina = GetComponentInChildren<Stamina>();
        }

        if (origin == _teamOrigin)
        {
            _playerName.UpdateName(name);
            _stamina.SetStamina(stamina);
        }
    }

    /// <summary>
    /// Sets the current shootpower on the UI
    /// </summary>
    /// <param name="value">Shootpower given by input</param>
    public void OnShoot(int value)
    {
        _shootPower.SetPower(value);
    }

    /// <summary>
    /// Updates the current stamina value on the UI
    /// </summary>
    /// <param name="stamina">Stamina by player</param>
    public void UpdateStamina(int stamina)
    {
        _stamina.SetStamina(stamina);
    }
}
