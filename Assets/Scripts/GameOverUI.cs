using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text finalScoreText;

    [Header("API")]
    public string startGameUrl = "https://fruit-merge-backend.onrender.com/game";

    void Start()
    {
        finalScoreText.text =
            KhmerNumerals.ToKhmerNumerals(
                ScoreManager.Instance.CurrentScore
            );
    }

    public void OnPlayAgain()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButton();
        }
        LoadingResult result = new LoadingResult();
        SceneTransition.LoadWithLoadingScene(
            operation: StartNewGame(result),
            result: result,
            successScene: "PlayScene",
            loadingScene: SceneTransition.DefaultLoadingSceneName
        );
    }

    public void OnQuit()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButton();
        }
        GameSession.Instance.ResetSession();
        SceneManager.LoadScene("WelcomeScene");
    }

    IEnumerator StartNewGame(LoadingResult result)
    {
        // reset local state first
        GameSession.Instance.ResetSession();

        UnityWebRequest req = new UnityWebRequest(startGameUrl, "POST");

        byte[] body = System.Text.Encoding.UTF8.GetBytes("{}");
        req.uploadHandler = new UploadHandlerRaw(body);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.result != UnityWebRequest.Result.Success)
        {
            result.success = false;
            result.error = req.error;
            yield break;
        }

        StartGameResponse response =
            JsonUtility.FromJson<StartGameResponse>(req.downloadHandler.text);

        GameSession.Instance.gameId = response.gameSessionId;
        result.success = true;
    }
}

