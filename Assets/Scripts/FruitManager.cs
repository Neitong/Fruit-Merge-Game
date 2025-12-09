using UnityEngine;

public class FruitManager : MonoBehaviour
{
    public Transform spawner;
    public GameObject[] fruits;  // Assign your prefabs here

    private GameObject currentFruit;

    void Start()
    {
        SpawnFruit();
    }

    void Update()
    {
        if (currentFruit != null)
        {
            // When player releases mouse
            if (Input.GetMouseButtonUp(0))
            {
                DropFruit();
            }
        }
    }

    void SpawnFruit()
    {
        int index = Random.Range(0, fruits.Length); // random fruit
        currentFruit = Instantiate(fruits[index], spawner.position, Quaternion.identity);

        // Freeze fruit, follow spawner
        var rb = currentFruit.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // Follow the spawner
        currentFruit.transform.SetParent(spawner);
    }

    void DropFruit()
    {
        var rb = currentFruit.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;                       // start falling
        rb.constraints = RigidbodyConstraints2D.None;

        currentFruit.transform.SetParent(null);    // detach from spawner
        currentFruit = null;

        // Spawn next fruit (delay optional)
        Invoke(nameof(SpawnFruit), 0.3f);
    }
}
