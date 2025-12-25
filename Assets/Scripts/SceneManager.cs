using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void GoToPlay()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButton();
        }
        SceneManager.LoadScene("PlayScene");
    }

    public void GoToLeaderboard()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButton();
        }
        SceneManager.LoadScene("LeaderboardScene");
    }

    public void GoToWelcome()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButton();
        }
        SceneManager.LoadScene("WelcomeScene");
    }

    public void GoToPause()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButton();
        }
        SceneManager.LoadScene("PauseScene");
    }

    public void GoToGameOver()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButton();
        }
        SceneManager.LoadScene("GameOverScene");
    }
    public void GoToGameWin()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButton();
        }
        SceneManager.LoadScene("GameWinScene");
    }
    public void GoToAboutUs()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButton();
        }
        SceneManager.LoadScene("AboutScene");
    }
}