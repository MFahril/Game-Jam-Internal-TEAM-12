using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifeTime = 0.1f; // Waktu hidup ledakan
    public int damage = 5; // Damage yang diberikan oleh ledakan

    void Start()
    {
<<<<<<< Updated upstream
        Destroy(gameObject, lifeTime); // Hancurkan explosion setelah waktu tertentu
    }

=======
        // Inisialisasi jika perlu
    }

    void Update()
    {
        // Menghancurkan objek explosion setelah waktu tertentu
        Destroy(this.gameObject, lifeTime);
    }

>>>>>>> Stashed changes
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
<<<<<<< Updated upstream
            Stats enemyStats = other.GetComponent<Stats>();
            if (enemyStats != null) // Memeriksa apakah enemy memiliki komponen Stats
            {
                enemyStats.TakeDamage(this.GetComponent<Stats>().damage);
            }
            Destroy(gameObject); // Hancurkan explosion setelah tabrakan
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

            Destroy(this.gameObject); // Menghancurkan ledakan setelah tabrakan
>>>>>>> Stashed changes
        }
    }
}
