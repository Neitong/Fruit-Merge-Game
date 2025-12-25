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
                GameSession.Instance.sessionScore
            );
    }

    public void OnPlayAgain()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButton();
        }
        StartCoroutine(StartNewGame());
    }

    public void OnQuit()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButton();
        }
        GameSession.Instance.ResetSession();
        SceneManager.LoadScene("Welcome");
    }

    IEnumerator StartNewGame()
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
            Debug.LogError("Start new game failed: " + req.error);
            yield break;
        }

        StartGameResponse response =
            JsonUtility.FromJson<StartGameResponse>(req.downloadHandler.text);

        GameSession.Instance.gameId = response.gameSessionId;

        SceneManager.LoadScene("PlayScene");
    }
}

