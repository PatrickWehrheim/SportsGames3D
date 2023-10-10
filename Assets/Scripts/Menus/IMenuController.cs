

public interface IMenuController
{
    /// <summary>
    /// Show the real sports menu
    /// </summary>
    void ShowRealSportsMenu();
    /// <summary>
    /// Show the e-sports menu
    /// </summary>
    void ShowESportsMenu();
    /// <summary>
    /// Show the options menu
    /// </summary>
    void ShowOptionsMenu();
    /// <summary>
    /// Show the credits menu
    /// </summary>
    void ShowCreditsMenu();
    /// <summary>
    /// Show the soccer game main menu
    /// </summary>
    void OpenSoccerGame();
    /// <summary>
    /// Show the football game main menu
    /// </summary>
    void OpenFootballGame();
    /// <summary>
    /// Show the tennis game main menu
    /// </summary>
    void OpenTennisGame();
    /// <summary>
    /// Show the golf game main menu
    /// </summary>
    void OpenGolfGame();
    /// <summary>
    /// Show the soccer selection scene
    /// </summary>
    void ShowSoccerSelectScene();
    /// <summary>
    /// Set the selected team
    /// </summary>
    /// <param name="team">Selected team</param>
    /// <param name="teamOrigin">Team side</param>
    void OnTeamSelect(Team team, TeamOrigin teamOrigin);
    /// <summary>
    /// Start the soccer game
    /// </summary>
    void ShowSoccerGameScene();
    /// <summary>
    /// Show the soccer tutorial
    /// </summary>
    void ShowSoccerTutorialScene();
    /// <summary>
    /// Close the game
    /// or stops the running editor
    /// </summary>
    void QuitGame();
    /// <summary>
    /// Opens the scene depending on the origin
    /// </summary>
    void OnBack();
    /// <summary>
    /// Show the not implemented scene
    /// </summary>
    void ShowNotImpementedScene();
    /// <summary>
    /// Show the soccer main menu
    /// </summary>
    void OnBackToSoccerMenu();
    /// <summary>
    /// Show or hide the pause menu
    /// </summary>
    void OnPause();
}
