using UnityEngine;

public class FruitDragController : MonoBehaviour
{
    public float minX = -1.5f;
    public float maxX = 1.5f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float clampedX = Mathf.Clamp(worldPos.x, minX, maxX);

            transform.position = new Vector3(clampedX, transform.position.y, 0);
        }
    }
}
