using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<GameObject> HomePlayers = new List<GameObject>();
    public List<GameObject> AwayPlayers = new List<GameObject>();
    public SelectedPlayerManager SelectedPlayerManager;

    private GameObject _controlledPlayer;
    private float _staminaCounter;

    public static PlayerManager Instance;
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
        DontDestroyOnLoad(this);
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.IsGamePaused)
        {
            return;
        }

        GameObject nearastPlayer = GameManager.Instance.GetNearestPlayer(GameManager.Instance.Ball, false);
        if (_controlledPlayer == null || _controlledPlayer != nearastPlayer)
        {
            Player player = nearastPlayer.GetComponent<Player>();
            SelectedPlayerManager.ChangePlayer(player.TeamOrigin, player.Name, player.Stamina);
            _controlledPlayer = nearastPlayer;
        }

        _staminaCounter += Time.deltaTime;
        if (_staminaCounter >= 1f)
        {
            _controlledPlayer.GetComponent<Player>().Stamina -= (int)_staminaCounter;
            _staminaCounter = 0f;
            SelectedPlayerManager.UpdateStamina(_controlledPlayer.GetComponent<Player>().Stamina);
        }
    }
}
