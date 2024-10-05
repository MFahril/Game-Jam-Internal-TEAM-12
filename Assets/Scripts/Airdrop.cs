using UnityEngine;

public class Airdrop : MonoBehaviour
{
    public float fallSpeed = 2f; 
    private Vector2 targetPosition; 
    private Rigidbody2D rb;
    private float startX; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startX = transform.position.x; 
    }

    void Update()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(0, -fallSpeed);

            if (transform.position.y <= targetPosition.y)
            {
                rb.velocity = Vector2.zero;
                transform.position = new Vector2(startX, targetPosition.y);
            }
        }
    }

    public void SetTargetPosition(Vector2 position)
    {
        targetPosition = new Vector2(startX, position.y);
    }
}
