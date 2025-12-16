using UnityEngine;

public class FruitManager : MonoBehaviour
{
    public Transform spawner;
    public GameObject[] fruits;  // Assign your prefabs here
    public float spawnDelayAfterLanding = 0.5f; // Delay after fruit lands
    public float maxSpawnWaitTime = 2f; // Maximum time to wait before spawning anyway

    private GameObject currentFruit;
    private GameObject droppedFruit; // Track the fruit that was just dropped
    private bool isDropping = false;
    private bool isWaitingForLanding = false;
    private float dropTime = 0f;
    private float settledTime = 0f;
    private bool hasStartedSettling = false;

    void Start()
    {
        SpawnFruit();
    }

    void Update()
    {
        if (currentFruit != null && !isDropping && !isWaitingForLanding)
        {
            // When player releases mouse
            if (Input.GetMouseButtonUp(0))
            {
                DropFruit();
            }
        }

        // Check if dropped fruit has landed
        if (isWaitingForLanding)
        {
            if (droppedFruit == null)
            {
                // Fruit was destroyed (merged), wait a moment then spawn
                isWaitingForLanding = false;
                if (!IsInvoking(nameof(SpawnFruit)))
                {
                    Invoke(nameof(SpawnFruit), spawnDelayAfterLanding);
                }
            }
            else
            {
                CheckIfFruitLanded();
            }
        }
    }

    void CheckIfFruitLanded()
    {
        Rigidbody2D rb = droppedFruit.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            // No rigidbody, consider it landed
            isWaitingForLanding = false;
            droppedFruit = null;
            if (!IsInvoking(nameof(SpawnFruit)))
            {
                Invoke(nameof(SpawnFruit), spawnDelayAfterLanding);
            }
            return;
        }

        // Check if fruit has stopped moving (landed)
        bool isSettled = rb.velocity.magnitude < 0.1f && Mathf.Abs(rb.angularVelocity) < 0.1f;

        if (isSettled)
        {
            if (!hasStartedSettling)
            {
                hasStartedSettling = true;
                settledTime = Time.time;
            }
            else if (Time.time - settledTime >= 0.2f) // Been settled for 0.2 seconds
            {
                // Fruit has been settled, spawn next one
                isWaitingForLanding = false;
                hasStartedSettling = false;
                droppedFruit = null;
                if (!IsInvoking(nameof(SpawnFruit)))
                {
                    Invoke(nameof(SpawnFruit), spawnDelayAfterLanding);
                }
            }
        }
        else
        {
            // Still moving, reset settling timer
            hasStartedSettling = false;
        }

        // Safety timeout - spawn anyway after max wait time
        if (Time.time - dropTime > maxSpawnWaitTime && !IsInvoking(nameof(SpawnFruit)))
        {
            isWaitingForLanding = false;
            hasStartedSettling = false;
            droppedFruit = null;
            Invoke(nameof(SpawnFruit), spawnDelayAfterLanding);
        }
    }

    void SpawnFruit()
    {
        if (fruits == null || fruits.Length == 0) return;

        int index = Random.Range(0, fruits.Length); // random fruit
        currentFruit = Instantiate(fruits[index], spawner.position, Quaternion.identity);

        // Freeze fruit, follow spawner
        var rb = currentFruit.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        // Follow the spawner
        currentFruit.transform.SetParent(spawner);
        isDropping = false;
        isWaitingForLanding = false;
    }

    void DropFruit()
    {
        if (currentFruit == null || isDropping) return;

        isDropping = true;
        isWaitingForLanding = true;
        dropTime = Time.time;
        hasStartedSettling = false;

        var rb = currentFruit.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 1;                       // start falling
            rb.constraints = RigidbodyConstraints2D.None;
        }

        droppedFruit = currentFruit; // Track this fruit
        droppedFruit.transform.SetParent(null);    // detach from spawner
        currentFruit = null;
    }
}
