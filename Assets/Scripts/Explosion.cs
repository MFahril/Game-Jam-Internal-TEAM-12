using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifeTime = 0.1f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // Hancurkan explosion setelah waktu tertentu
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Stats enemyStats = other.GetComponent<Stats>();
            if (enemyStats != null) // Memeriksa apakah enemy memiliki komponen Stats
            {
                enemyStats.TakeDamage(this.GetComponent<Stats>().damage);
            }
            Destroy(gameObject); // Hancurkan explosion setelah tabrakan
        }
    }
}
