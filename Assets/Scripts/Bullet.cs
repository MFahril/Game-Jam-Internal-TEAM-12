using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;
    private Rigidbody2D rb;
    public int damage = 1; // Damage untuk bullet

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); // Hancurkan bullet setelah waktu tertentu
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Stats enemyStats = other.GetComponent<Stats>();
            if (enemyStats != null) // Memeriksa apakah enemy memiliki komponen Stats
            {
                enemyStats.TakeDamage(damage); // Gunakan damage yang telah ditentukan
            }
            Destroy(gameObject); // Hancurkan bullet setelah tabrakan
        }
    }
}
