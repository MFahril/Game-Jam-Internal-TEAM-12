using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
<<<<<<< Updated upstream
    public float lifeTime = 3f;
    private Rigidbody2D rb;
    public int damage = 1; // Damage untuk bullet
=======
    public float lifeTime = 3f;                // Waktu hidup peluru
    private Rigidbody2D rb;                     // Referensi ke Rigidbody2D
    public float knockbackStrength = 5f;        // Kekuatan knockback
    public int damage = 1;                      // Damage yang diberikan oleh peluru
>>>>>>> Stashed changes

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); // Hancurkan bullet setelah waktu tertentu
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
<<<<<<< Updated upstream
            Stats enemyStats = other.GetComponent<Stats>();
            if (enemyStats != null) // Memeriksa apakah enemy memiliki komponen Stats
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

            // Menambahkan efek knockback ke musuh
            EnemyData enemyData = other.GetComponent<EnemyData>();
            if (enemyData != null)
>>>>>>> Stashed changes
            {
                enemyStats.TakeDamage(damage); // Gunakan damage yang telah ditentukan
            }
<<<<<<< Updated upstream
            Destroy(gameObject); // Hancurkan bullet setelah tabrakan
=======
            else
            {
                Debug.LogWarning("Enemy does not have EnemyData component!");
            }

            Destroy(this.gameObject); // Menghancurkan peluru setelah mengenai musuh
>>>>>>> Stashed changes
        }
    }
}
