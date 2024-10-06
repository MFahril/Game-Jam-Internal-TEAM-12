using System.Collections;
using UnityEngine;

public class BossData : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan boss
    public int health = 50; // Kesehatan boss
    public int damage = 10; // Damage boss
    public Transform playerTransform; // Referensi ke pemain
    private EnemySpawner enemySpawner; // Referensi untuk EnemySpawner

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>(); // Mendapatkan referensi EnemySpawner
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
            else
            {
                playerTransform.GetComponent<Stats>().TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (enemySpawner != null)
        {
            enemySpawner.bossAlive = false; // Menandakan boss sudah mati
        }
        Destroy(gameObject); // Menghancurkan boss
    }
}
