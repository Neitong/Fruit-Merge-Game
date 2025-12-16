using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;
    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }
}
