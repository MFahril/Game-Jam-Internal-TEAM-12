using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
<<<<<<< Updated upstream
    public float lifeTime = 3f;
    private Rigidbody2D rb;
    public float knockbackStrength = 5f; // Kekuatan knockback
=======
    public float lifeTime = 3f;                // Waktu hidup peluru
    private Rigidbody2D rb;                     // Referensi ke Rigidbody2D
    public float knockbackStrength = 5f;        // Kekuatan knockback
    public int damage = 1;                      // Damage yang diberikan oleh peluru
>>>>>>> Stashed changes

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); // Menghancurkan peluru setelah beberapa detik
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
<<<<<<< Updated upstream
            // Mengurangi health musuh
            other.GetComponent<Stats>().health -= this.GetComponent<Stats>().damage;
=======
            // Cek apakah enemy adalah boss
            BossData bossData = other.GetComponent<BossData>();
            if (bossData != null)
            {
                // Jika musuh adalah boss, berikan damage langsung
                bossData.TakeDamage(damage);
            }
            else
            {
                // Mengambil komponen Stats dari musuh
                Stats enemyStats = other.GetComponent<Stats>();
                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(damage); // Gunakan metode TakeDamage
                }
                else
                {
                    Debug.LogWarning("Enemy does not have Stats component!");
                }
            }
>>>>>>> Stashed changes

            // Menambahkan efek knockback ke musuh
            EnemyData enemyData = other.GetComponent<EnemyData>();
            if (enemyData != null)
            {
                Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                enemyData.ApplyKnockback(knockbackDirection, knockbackStrength);
<<<<<<< Updated upstream
=======
            }
            else
            {
                Debug.LogWarning("Enemy does not have EnemyData component!");
>>>>>>> Stashed changes
            }

            Destroy(this.gameObject); // Menghancurkan peluru setelah mengenai musuh
        }
    }
}
