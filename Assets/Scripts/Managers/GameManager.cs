using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private OptionsData _optionsData;

    public GameObject Ball;

    [SerializeField] private GameObject _homePlayer;
    [SerializeField] private GameObject _awayPlayer;

    [SerializeField] private GameObject _homeGoal;
    public GameObject HomeGoal { get { return _homeGoal; } private set { _homeGoal = value; } }

    [SerializeField] private GameObject _awayGoal;
    public GameObject AwayGoal { get { return _awayGoal; } private set { _awayGoal = value; } }

    public SelectedPlayerManager SelectedPlayerManagerHome;
    public SelectedPlayerManager SelectedPlayerManagerAway;

    private MenuController _menuController;
    public MenuController MenuController { get { return _menuController; } private set { _menuController = value; } }
    
    public int HomeGoals = 0;
    public int AwayGoals = 0;
    public bool IsGamePaused = false;
    public bool IsGameEnded = false;
    public bool RespawnNeeded = false;

    private Vector2[] _homePlayerSpawnCords;
    private Vector2[] _awayPlayerSpawnCords;

    private GameObject _activePlayer;
    private float _staminaCounter;

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance.Ball == null)
                Instance.Ball = this.Ball;
            if (Instance.HomeGoal == null)
                Instance.HomeGoal = this.HomeGoal;
            if (Instance.AwayGoal == null)
                Instance.AwayGoal = this.AwayGoal;

            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);

        MenuController = MenuManager.Instance.MenuController;
        PlayerManager.Instance.SelectedPlayerManager = SelectedPlayerManagerAway;

        _gameData.HomeTeamName = MenuController.SelectedHomeTeam.Name;
        _gameData.AwayTeamName = MenuController.SelectedAwayTeam.Name;

        _gameData.GoalsHome = 0;
        _gameData.GoalsAway = 0;
    }

    private void Start()
    {
        StartCoroutine(SpawnPlayers());
    }

    private void FixedUpdate()
    {
        _staminaCounter += Time.deltaTime;
        if (_staminaCounter >= 1f)
        {
            _activePlayer.GetComponent<Player>().Stamina -= (int)_staminaCounter;
            _staminaCounter = 0f;
            SelectedPlayerManagerHome.UpdateStamina(_activePlayer.GetComponent<Player>().Stamina);
        }
    }

    /// <summary>
    /// Helperfunction: Wait for the ContestManager to load all teams
    /// Use this as coroutine
    /// </summary>
    /// <returns>IEnumeration</returns>
    private IEnumerator SpawnPlayers()
    {
        while (!ContestManager.Instance.ContestsLoaded)
        {
            yield return null;
        }
        SpawnPlayers(MenuController.SelectedHomeTeam, MenuController.SelectedAwayTeam);
    }

    /// <summary>
    /// Spawns the players on the field in te given formation
    /// </summary>
    /// <param name="teamHome">The home team</param>
    /// <param name="teamAway">The away team</param>
    private void SpawnPlayers(Team teamHome, Team teamAway)
    {
        _homePlayerSpawnCords = PlayerSpawnCords.GetPlayerHomeCords();
        _awayPlayerSpawnCords = PlayerSpawnCords.GetPlayerAwayCords();

        //Home player spawn
        for (int i = 0; i < teamHome.Players.Count; i++)
        {
            //Get a player from the team
            PlayerBase playerBase = teamHome.Players[i];
            //Instatiate a player GameObject at the given position
            GameObject spawnedPlayer = Instantiate(_homePlayer, new Vector3(_homePlayerSpawnCords[i].x, 1, _homePlayerSpawnCords[i].y), Quaternion.identity);
            //Get the player component and set the player properties in the GameObject
            Player player = spawnedPlayer.GetComponent<Player>();
            player.Name = playerBase.Name;
            player.Position = playerBase.Position;
            player.Stamina = playerBase.Stamina;
            player.TeamOrigin = TeamOrigin.Home;

            //the last player is set as the first controlled player
            if (i == teamHome.Players.Count - 1)
            {
                spawnedPlayer.GetComponent<PlayerController>().IsControlledByPlayer = true;
                SelectedPlayerManagerHome.ChangePlayer(player.TeamOrigin,
                    player.Name, player.Stamina);
                spawnedPlayer.GetComponentInChildren<Canvas>().enabled = true;
                _activePlayer = spawnedPlayer;
                _staminaCounter = 0;
            }
            PlayerManager.Instance.HomePlayers.Add(spawnedPlayer);
        }

        //Spawn away players
        for (int i = 0; i < teamAway.Players.Count; i++)
        {
            PlayerBase playerBase = teamAway.Players[i];
            GameObject spawnedPlayer = Instantiate(_awayPlayer, new Vector3(_awayPlayerSpawnCords[i].x, 1, _awayPlayerSpawnCords[i].y), Quaternion.identity);
            Player player = spawnedPlayer.GetComponent<Player>();
            player.Name = playerBase.Name;
            player.Position = playerBase.Position;
            player.Stamina = playerBase.Stamina;
            player.TeamOrigin = TeamOrigin.Away;
            PlayerManager.Instance.AwayPlayers.Add(spawnedPlayer);
        }
    }

    /// <summary>
    /// Adds one scorepoint to the opponent team
    /// </summary>
    /// <param name="origin">The team where the goal happend</param>
    public void AddScore(TeamOrigin origin)
    {
        if (origin == TeamOrigin.Home)
        {
            UIManager.Instance.AddAwayGoal();
        }
        else if (origin == TeamOrigin.Away)
        {
            UIManager.Instance.AddHomeGoal();
        }
    }

    /// <summary>
    /// Gets called if pause is pressed
    /// Opens or closes the pause scene
    /// </summary>
    /// <param name="context">Inputaction context</param>
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (SceneManager.GetSceneAt(SceneManager.sceneCount - 1).buildIndex == (int)Scenes.PauseMenu)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex((int)Scenes.PauseMenu));
                IsGamePaused = false;
                UIManager.Instance.ShowUI();
            }
            else
            {
                SceneManager.LoadSceneAsync((int)Scenes.PauseMenu, LoadSceneMode.Additive);
                IsGamePaused = true;
                UIManager.Instance.HideUI();
            }
        }
    }

    /// <summary>
    /// Loads the pause scene and resets all player positions
    /// </summary>
    public void OnHalfTime()
    {
        SceneManager.LoadSceneAsync((int)Scenes.PauseMenu, LoadSceneMode.Additive);
        IsGamePaused = true;
        RespawnNeeded = true;
        UIManager.Instance.HideUI();
        ResetPlayers();
    }

    /// <summary>
    /// Loads the puse scene and ends the game
    /// </summary>
    public void OnFullTime()
    {
        SceneManager.LoadSceneAsync((int)Scenes.PauseMenu, LoadSceneMode.Additive);
        IsGamePaused = true;
        IsGameEnded = true;
        UIManager.Instance.HideUI();
    }

    /// <summary>
    /// Gets called if the player gets changed
    /// Change the current controlled player
    /// </summary>
    /// <param name="context">Inputaction context</param>
    public void OnChangePlayer(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ChangeControlledPlayer();
        }
    }

    /// <summary>
    /// Checks if another player is nearer to the ball than the current player
    /// Change the player to the nearest player to the ball
    /// </summary>
    private void ChangeControlledPlayer()
    {
        _activePlayer.GetComponent<PlayerController>().IsControlledByPlayer = false;
        _activePlayer.GetComponentInChildren<Canvas>().enabled = false;
        GameObject closestPlayer = GetNearestPlayer(Ball, true);

        if (closestPlayer != null)
        {
            _activePlayer = closestPlayer;
            Player player = _activePlayer.GetComponent<Player>();
            _activePlayer.GetComponent<PlayerController>().IsControlledByPlayer = true;
            _activePlayer.GetComponentInChildren<Canvas>().enabled = true;
            SelectedPlayerManagerHome.ChangePlayer(player.TeamOrigin, player.Name, player.Stamina);
        }
    }

    /// <summary>
    /// Get the nearest player depends on the given GameObject
    /// </summary>
    /// <param name="relativeTo">GameObject to check the distance</param>
    /// <param name="isFromHome">Check for players on the home team if true, else from the away team</param>
    /// <returns>The nearest player from the given team</returns>
    public GameObject GetNearestPlayer(GameObject relativeTo, bool isFromHome)
    {
        return GetNearestPlayer(relativeTo.transform.position, isFromHome);
    }

    /// <summary>
    /// Get the nearest player depends on the given position
    /// </summary>
    /// <param name="position">Position to check the distance</param>
    /// <param name="isFromHome">Check for players on the home team if true, else from the away team</param>
    /// <returns>The nearest player from the given team</returns>
    public GameObject GetNearestPlayer(Vector3 position, bool isFromHome)
    {
        GameObject closestPlayer = null;
        float minDistance = 1000f;
        if (isFromHome)
        {
            foreach (GameObject player in PlayerManager.Instance.HomePlayers)
            {
                float distance = Vector3.Distance(position, player.transform.position);
                if (distance < minDistance && distance != 0)
                {
                    closestPlayer = player;
                    minDistance = distance;
                }
            }
        }
        else
        {
            foreach (GameObject player in PlayerManager.Instance.AwayPlayers)
            {
                float distance = Vector3.Distance(position, player.transform.position);
                if (distance < minDistance && distance != 0)
                {
                    closestPlayer = player;
                    minDistance = distance;
                }
            }
        }

        return closestPlayer;
    }

    /// <summary>
    /// Reset all player positions
    /// </summary>
    public void OnGoal()
    {
        RespawnNeeded = true;
        StartCoroutine(ResetPlayers());
    }

    /// <summary>
    /// Respawns the nearest player to the given position with the ball in front of him
    /// Set the player as controlled player if is not last touched by home team
    /// </summary>
    /// <param name="position">Position where the ball gets respawned</param>
    /// <param name="isFromHomeTeam">Is the ball last touched by the home team</param>
    public void OnBallOutAtSideLine(Vector3 position, bool isFromHomeTeam)
    {
        GameObject player;
        if (!isFromHomeTeam)
        {
            player = GetNearestPlayer(position, true);
        }
        else
        {
            player = GetNearestPlayer(position, false);
        }

        player.transform.position = new Vector3(position.x, 1f, position.z);
        player.transform.rotation = Quaternion.Euler(0, -90, 0);
        Ball.transform.position = position + player.transform.right;
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (!isFromHomeTeam) ChangeControlledPlayer();
    }

    /// <summary>
    /// Respawns the ball at the five meter room on the given team side with the nearest player behind it
    /// Change the controlled player if its on home side
    /// </summary>
    /// <param name="teamSide">The side where the ball goes outside</param>
    public void OnBallOutAtGoalLine(TeamOrigin teamSide)
    {
        Vector3 position;
        if (teamSide == TeamOrigin.Home)
        {
            position = new Vector3(-77f, 0.32f, 12.5f);
            GameObject player = GetNearestPlayer(position, true);
            player.transform.position = new Vector3(position.x - 1, 1f, position.z);
        }
        else
        {
            position = new Vector3(77f, 0.32f, -12.5f);
            GameObject player = GetNearestPlayer(position, false);
            player.transform.position = new Vector3(position.x + 1, 1f, position.z);
        }
        Ball.transform.position = position;
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (teamSide == TeamOrigin.Home)
        {
            ChangeControlledPlayer();
        }
    }

    /// <summary>
    /// Resets all player positions to the given formations
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator ResetPlayers()
    {
        yield return new WaitForSeconds(2);

        List<GameObject> homePlayers = PlayerManager.Instance.HomePlayers;
        List<GameObject> awayPlayers = PlayerManager.Instance.AwayPlayers;

        for (int i = 0; i < homePlayers.Count; i++)
        {
            Vector3 position = homePlayers[i].transform.position;
            position.x = _homePlayerSpawnCords[i].x;
            position.z = _homePlayerSpawnCords[i].y;
            homePlayers[i].transform.position = position;
        }

        for (int i = 0; i < awayPlayers.Count; i++)
        {
            Vector3 position = awayPlayers[i].transform.position;
            position.x = _awayPlayerSpawnCords[i].x;
            position.z = _awayPlayerSpawnCords[i].y;
            awayPlayers[i].transform.position = position;
        }

        Ball.transform.position = new Vector3(0, 0.5f, 0);
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        RespawnNeeded = false;
    }

    /// <summary>
    /// Helperfunction: Destroy a GameObject
    /// Call this if a non MonoBehaviour script needs to destroy an object
    /// </summary>
    /// <param name="o">The object to destroy</param>
    public void DestroyObjectFromGame(GameObject o)
    {
        Destroy(o);
    }
}
