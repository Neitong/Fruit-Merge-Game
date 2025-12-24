using UnityEngine;
using TMPro;

public class PlaySceneUI : MonoBehaviour
{
    public TMP_Text GameID;

    void Start()
    {
        if (GameSession.Instance != null)
        {
            GameID.text = GameSession.Instance.gameId;
        }
    }
}
