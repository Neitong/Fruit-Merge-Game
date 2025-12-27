using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

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
        // Show LoadingScene while fetching leaderboard, then load LeaderboardScene
        LoadingResult result = new LoadingResult();
        SceneTransition.LoadWithLoadingScene(
            operation: FetchLeaderboard(result),
            result: result,
            successScene: "LeaderboardScene",
            loadingScene: SceneTransition.DefaultLoadingSceneName,
            failScene: "LeaderboardScene" // still show the scene even if fetch fails
        );
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

    private IEnumerator FetchLeaderboard(LoadingResult result)
    {
        // If LeaderboardScene also fetches, this cache makes it instant after the loading screen.
        LeaderboardCache.Clear();

        // NOTE: We don't have a central config class yet, so keep this in sync with LeaderboardManager.
        const string leaderboardUrl = "https://fruit-merge-backend.onrender.com/game/leaderboard";

        using (UnityWebRequest req = UnityWebRequest.Get(leaderboardUrl))
        {
            yield return req.SendWebRequest();

            if (req.result != UnityWebRequest.Result.Success)
            {
                result.success = false;
                result.error = req.error;
                yield break;
            }

            string json = req.downloadHandler.text;

            // Backend returns a raw array, JsonUtility needs an object wrapper.
            string wrappedJson = "{\"leaderboard\":" + json + "}";
            LeaderboardResponse response = JsonUtility.FromJson<LeaderboardResponse>(wrappedJson);

            if (response == null || response.leaderboard == null)
            {
                result.success = false;
                result.error = "Invalid leaderboard response";
                yield break;
            }

            LeaderboardCache.Entries = response.leaderboard;
            result.success = true;
        }
    }
}