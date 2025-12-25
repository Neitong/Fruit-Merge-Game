using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class TopBoundaryLose : MonoBehaviour
{
    public string baseUrl = "https://fruit-merge-backend.onrender.com/game";
    public float loseDelay = 1.2f; // seconds before losing

    private bool isGameOver = false;

    // Track how long each fruit stays in top zone
    private Dictionary<GameObject, float> stayTimers = new Dictionary<GameObject, float>();

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isGameOver) return;
        if (!other.CompareTag("Fruit")) return;

        Rigidbody2D rb = other.attachedRigidbody;
        if (rb == null) return;

        // Ignore fast-moving (falling) fruits
        if (rb.velocity.magnitude > 0.1f)
        {
            stayTimers[other.gameObject] = 0f;
            return;
        }

        // Count time staying near stopped
        if (!stayTimers.ContainsKey(other.gameObject))
            stayTimers[other.gameObject] = 0f;

        stayTimers[other.gameObject] += Time.deltaTime;

        if (stayTimers[other.gameObject] >= loseDelay)
        {
            Debug.Log("Fruit stayed too long at top → GAME OVER");
            isGameOver = true;
            StartCoroutine(SendFinalScore());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (stayTimers.ContainsKey(other.gameObject))
            stayTimers.Remove(other.gameObject);
    }

    IEnumerator SendFinalScore()
    {
        string sessionId = GameSession.Instance.gameId;
        int finalScore = ScoreManager.Instance.CurrentScore;

        string url = $"{baseUrl}/{sessionId}/score";
        string json = JsonUtility.ToJson(new ScorePayload(finalScore));

        byte[] body = System.Text.Encoding.UTF8.GetBytes(json);

        UnityWebRequest req = new UnityWebRequest(url, "PUT");
        req.uploadHandler = new UploadHandlerRaw(body);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        SceneManager.LoadScene("GameOverScene");
    }
}

[System.Serializable]
public class ScorePayload
{
    public int score;

    public ScorePayload(int score)
    {
        this.score = score;
    }
}
