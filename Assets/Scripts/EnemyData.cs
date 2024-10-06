using System.Collections;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 3f;
    private bool isAttacking = false;
    public Rigidbody2D rb; // Referensi Rigidbody2D untuk knockback
    public int health = 5; // Kesehatan musuh

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, playerTransform.position);

            if (distance > 0.5f)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
            else if (!isAttacking)
            {
                StartCoroutine(AttackPlayer());
            }
        }
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        while (Vector3.Distance(transform.position, playerTransform.position) <= 0.5f)
        {
            playerTransform.GetComponent<Stats>().TakeDamage(2);
            yield return new WaitForSeconds(0.5f);
        }
        isAttacking = false;
    }

    // Metode untuk menerapkan knockback
    public void ApplyKnockback(Vector2 direction, float strength)
    {
        rb.AddForce(direction * strength, ForceMode2D.Impulse); // Menggunakan impuls untuk knockback
    }
}
