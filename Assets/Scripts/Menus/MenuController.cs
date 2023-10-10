using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : IMenuController
{
    private int _currentSceneIndex;
    private int _lastSceneIndex;

    public Team SelectedHomeTeam { get; set; }
    public Team SelectedAwayTeam { get; set; }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(0);
#endif
    }

    public void ShowCreditsMenu()
    {
        SceneManager.UnloadSceneAsync(_currentSceneIndex);
        SceneManager.LoadSceneAsync((int)Scenes.CreditsMenu);
        _lastSceneIndex = _currentSceneIndex;
        _currentSceneIndex = (int)Scenes.CreditsMenu;
    }

    public void ShowESportsMenu()
    {
        SceneManager.UnloadSceneAsync(_currentSceneIndex);
        SceneManager.LoadSceneAsync((int)Scenes.ESportsMenu);
        _lastSceneIndex = _currentSceneIndex;
        _currentSceneIndex = (int)Scenes.ESportsMenu;
    }

    public void ShowOptionsMenu()
    {
        SceneManager.LoadScene((int)Scenes.OptionsMenu, LoadSceneMode.Additive);
        _lastSceneIndex = _currentSceneIndex;
        _currentSceneIndex = (int)Scenes.OptionsMenu;
    }

    public void ShowRealSportsMenu()
    {
        SceneManager.UnloadSceneAsync(_currentSceneIndex);
        SceneManager.LoadSceneAsync((int)Scenes.RealSportsMenu);
        _lastSceneIndex = _currentSceneIndex;
        _currentSceneIndex = (int)Scenes.RealSportsMenu;
    }

    public void OnBack()
    {
        switch (_currentSceneIndex)
        {
            case (int)Scenes.ESportsMenu:
                _lastSceneIndex = (int)Scenes.MainMenu;
                break;
            case (int)Scenes.RealSportsMenu:
                _lastSceneIndex = (int)Scenes.MainMenu;
                break;
            case (int)Scenes.SoccerMainMenu:
                _lastSceneIndex = (int)Scenes.RealSportsMenu;
                break;
            case (int)Scenes.SoccerSelectMenu:
                _lastSceneIndex = (int)Scenes.SoccerMainMenu;
                break;
            case (int)Scenes.PauseMenu:
                _lastSceneIndex = (int)Scenes.SoccerMainMenu;
                break;
            case (int)Scenes.OptionsMenu:
                SceneManager.UnloadSceneAsync(_currentSceneIndex);
                _currentSceneIndex = _lastSceneIndex;
                return;

        }
        SceneManager.UnloadSceneAsync(_currentSceneIndex);
        SceneManager.LoadSceneAsync(_lastSceneIndex);
        _currentSceneIndex = _lastSceneIndex;
    }

    public void OpenSoccerGame()
    {
        SceneManager.UnloadSceneAsync(_currentSceneIndex);
        SceneManager.LoadSceneAsync((int)Scenes.SoccerMainMenu);
        _lastSceneIndex = _currentSceneIndex;
        _currentSceneIndex = (int)Scenes.SoccerMainMenu;
    }

    public void OpenFootballGame()
    {
        SceneManager.UnloadSceneAsync(_currentSceneIndex);
        SceneManager.LoadSceneAsync((int)Scenes.NotImplementedScene);
        _lastSceneIndex = _currentSceneIndex;
        _currentSceneIndex = (int)Scenes.NotImplementedScene;
    }

    public void OpenTennisGame()
    {
        SceneManager.UnloadSceneAsync(_currentSceneIndex);
        SceneManager.LoadSceneAsync((int)Scenes.NotImplementedScene);
        _lastSceneIndex = _currentSceneIndex;
        _currentSceneIndex = (int)Scenes.NotImplementedScene;
    }

    public void OpenGolfGame()
    {
        SceneManager.UnloadSceneAsync(_currentSceneIndex);
        SceneManager.LoadSceneAsync((int)Scenes.NotImplementedScene);
        _lastSceneIndex = _currentSceneIndex;
        _currentSceneIndex = (int)Scenes.NotImplementedScene;
    }

    public void ShowNotImpementedScene()
    {
        SceneManager.UnloadSceneAsync(_currentSceneIndex);
        SceneManager.LoadSceneAsync((int)Scenes.NotImplementedScene);
        _lastSceneIndex = _currentSceneIndex;
        _currentSceneIndex = (int)Scenes.NotImplementedScene;
    }

    public void ShowSoccerSelectScene()
    {
        SceneManager.UnloadSceneAsync(_currentSceneIndex);
        SceneManager.LoadSceneAsync((int)Scenes.SoccerSelectMenu);
        _lastSceneIndex = _currentSceneIndex;
        _currentSceneIndex = (int)Scenes.SoccerSelectMenu;
    }

    public void ShowSoccerGameScene()
    {
        if (SelectedAwayTeam != null && SelectedAwayTeam != null)
        {
            SceneManager.LoadScene((int)Scenes.SoccerGameScene);
            MenuManager.Instance.ToggleMusic(false);
            _lastSceneIndex = _currentSceneIndex;
            _currentSceneIndex = (int)Scenes.SoccerGameScene;
        }
    }

    public void OnTeamSelect(Team team, TeamOrigin teamOrigin)
    {
        if (teamOrigin == TeamOrigin.Home)
        {
            SelectedHomeTeam = team;
        }
        else
        {
            SelectedAwayTeam = team;
        }
    }

    public void OnBackToSoccerMenu()
    {
        GameManager.Instance.DestroyObjectFromGame(PlayerManager.Instance.gameObject);
        GameManager.Instance.DestroyObjectFromGame(GameManager.Instance.gameObject);
        MenuManager.Instance.ToggleMusic(true);
        OpenSoccerGame();
    }

    public void OnPause()
    {
        if (SceneManager.GetSceneAt(SceneManager.sceneCount - 1).buildIndex == (int)Scenes.PauseMenu)
        {
            if (!GameManager.Instance.IsGameEnded)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex((int)Scenes.PauseMenu));
                GameManager.Instance.IsGamePaused = false;
                UIManager.Instance.ShowUI();
            }
        }
        else
        {
            SceneManager.LoadSceneAsync((int)Scenes.PauseMenu, LoadSceneMode.Additive);
            GameManager.Instance.IsGamePaused = true;
            UIManager.Instance.HideUI();
        }
    }

    public void ShowSoccerTutorialScene()
    {
        SceneManager.UnloadSceneAsync(_currentSceneIndex);
        SceneManager.LoadScene((int)Scenes.TutorialScene);
        _lastSceneIndex = _currentSceneIndex;
        _currentSceneIndex = (int)Scenes.TutorialScene;
    }
}
