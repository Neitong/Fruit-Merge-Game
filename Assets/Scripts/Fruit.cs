using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int level;                 // 0 → 5
    public int mergeScore = 10;        // points gained when merging
    public GameObject nextFruitPrefab;

    private bool hasMerged = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasMerged) return;

        Fruit other = collision.gameObject.GetComponent<Fruit>();
        if (other == null) return;
        if (other.hasMerged) return;

        if (other.level == level)
        {
            // Don't merge if there's no next level fruit (highest level reached)
            if (nextFruitPrefab == null) return;

            hasMerged = true;
            other.hasMerged = true;

            Vector2 mergePos = (transform.position + other.transform.position) / 2f;

            // Spawn next fruit
            Instantiate(nextFruitPrefab, mergePos, Quaternion.identity);

            // Add score (with null check)
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(mergeScore);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
