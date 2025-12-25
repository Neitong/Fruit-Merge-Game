using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class StartGameButton : MonoBehaviour
{
    public string startGameUrl = "https://fruit-merge-backend.onrender.com/game";

    public void OnPlayClicked()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButton();
        }
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        using (UnityWebRequest req = new UnityWebRequest(startGameUrl, "POST"))
        {
            // empty JSON body
            byte[] body = System.Text.Encoding.UTF8.GetBytes("{}");
            req.uploadHandler = new UploadHandlerRaw(body);
            req.downloadHandler = new DownloadHandlerBuffer();

            req.SetRequestHeader("Content-Type", "application/json");
            Debug.Log("POST " + startGameUrl);

            yield return req.SendWebRequest();

            if (req.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Start game failed: " + req.error);
                yield break;
            }

            StartGameResponse response =
                JsonUtility.FromJson<StartGameResponse>(req.downloadHandler.text);

            GameSession.Instance.gameId = response.gameSessionId;

            SceneManager.LoadScene("PlayScene");
        }
    }
}

[System.Serializable]
public class StartGameResponse
{
    public string gameSessionId;
}
