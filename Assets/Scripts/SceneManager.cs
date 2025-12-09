using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void GoToPlay()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }

    public void GoToWelcome()
    {
        SceneManager.LoadScene("WelcomeScene");
    }

    public void GoToPause()
    {
        SceneManager.LoadScene("PauseScene");
    }

    public void GoToGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void GoToGameWin()
    {
        SceneManager.LoadScene("GameWinScene");
    }
}