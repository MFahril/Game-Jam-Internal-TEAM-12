using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;
    private Rigidbody2D rb;
    public float knockbackStrength = 5f; // Kekuatan knockback

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); // Menghancurkan peluru setelah beberapa detik
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Mengurangi health musuh
            other.GetComponent<Stats>().health -= this.GetComponent<Stats>().damage;

            // Menambahkan efek knockback ke musuh
            EnemyData enemyData = other.GetComponent<EnemyData>();
            if (enemyData != null)
            {
                Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                enemyData.ApplyKnockback(knockbackDirection, knockbackStrength);
            }

            Destroy(this.gameObject); // Menghancurkan peluru setelah mengenai musuh
        }
    }
}
