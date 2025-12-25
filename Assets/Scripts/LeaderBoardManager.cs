using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;

public class LeaderboardManager : MonoBehaviour
{
    public Transform content;
    public GameObject rowPrefab;

    [Header("API")]
    public string leaderboardUrl = "https://fruit-merge-backend.onrender.com/game/leaderboard";

    void Start()
    {
        StartCoroutine(FetchLeaderboard());
    }

    IEnumerator FetchLeaderboard()
    {
        using (UnityWebRequest req = UnityWebRequest.Get(leaderboardUrl))
        {
            yield return req.SendWebRequest();

            if (req.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Leaderboard fetch failed: " + req.error);
                yield break;
            }

            string json = req.downloadHandler.text;
            Debug.Log("Leaderboard JSON: " + json);

            // Wrap the array JSON to match LeaderboardResponse structure
            string wrappedJson = "{\"leaderboard\":" + json + "}";
            LeaderboardResponse response = JsonUtility.FromJson<LeaderboardResponse>(wrappedJson);

            if (response == null || response.leaderboard == null)
            {
                Debug.LogError("Invalid leaderboard response");
                yield break;
            }

            Populate(response.leaderboard);
        }
    }

    void Populate(LeaderboardEntry[] entries)
    {
        foreach (Transform child in content)
            Destroy(child.gameObject);

        for (int i = 0; i < entries.Length; i++)
        {
            GameObject row = Instantiate(rowPrefab, content);

            row.transform.Find("Rank").GetComponent<TMP_Text>().text =
                KhmerNumerals.ToKhmerNumerals($"#{i + 1}");
            row.transform.Find("Name").GetComponent<TMP_Text>().text = entries[i]._id;
            row.transform.Find("Score").GetComponent<TMP_Text>().text =
                KhmerNumerals.ToKhmerNumerals(entries[i].score);
        }
    }
}
