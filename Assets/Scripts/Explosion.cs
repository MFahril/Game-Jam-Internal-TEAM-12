using System.Collections;
using UnityEngine;
public class Explosion : MonoBehaviour
{
    public float lifeTime = 0.1f;

    public void Start()
    {
<<<<<<< Updated upstream
        
    }

    public void Update()
=======
        // Inisialisasi jika perlu
    }

    void Update()
>>>>>>> Stashed changes
    {
        Destroy(this.gameObject, lifeTime);
    }

<<<<<<< Updated upstream
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Stats>().health -= this.GetComponent<Stats>().damage;

            Destroy(this.gameObject, lifeTime);
=======
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
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

