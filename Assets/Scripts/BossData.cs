using System.Collections;
using UnityEngine;

public class BossData : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan boss
    public int health = 50;       // Kesehatan boss
    public int maxHealth = 50;    // Kesehatan maksimal boss
    public int damage = 10;       // Damage boss
    public Transform playerTransform; // Referensi ke pemain
    private EnemySpawner enemySpawner; // Referensi untuk EnemySpawner
    private bool isTouchingPlayer = false; // Untuk memeriksa apakah boss menyentuh pemain
    private float damageTimer = 0.5f; // Waktu antara setiap damage
    public bool isInvincible = false; // Flag untuk kebal

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
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
                isTouchingPlayer = false; // Reset saat tidak menyentuh pemain
            }
            else
            {
                if (!isTouchingPlayer)
                {
                    isTouchingPlayer = true; // Boss mulai menyentuh pemain
                    StartCoroutine(DealDamageToPlayer());
                }
            }
        }
    }

    private IEnumerator DealDamageToPlayer()
    {
        while (isTouchingPlayer)
        {
            playerTransform.GetComponent<Stats>().TakeDamage(damage);
            yield return new WaitForSeconds(damageTimer);
        }
    }

    public void TakeDamage(int amount)
    {
        if (!isInvincible) // Cek apakah boss tidak kebal
        {
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
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
