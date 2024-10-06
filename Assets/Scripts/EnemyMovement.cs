using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    public GameObject player;
    private Rigidbody2D rb;
    private bool isKnockback = false;
    private float knockbackTimer = 0f;
    public float knockbackDuration = 0.2f; // Durasi knockback

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Mendapatkan Rigidbody musuh
    }

    void Update()
    {
        if (!isKnockback)
        {
            MoveTowardsPlayer();
        }
        else
        {
            knockbackTimer -= Time.deltaTime;
            if (knockbackTimer <= 0)
            {
                isKnockback = false; // Menghentikan knockback setelah waktunya habis
            }
        }
    }

    void MoveTowardsPlayer()
    {
        // Musuh bergerak menuju pemain
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
    }

    public void ApplyKnockback(Vector2 knockbackDirection, float knockbackStrength)
    {
        isKnockback = true; // Aktifkan mode knockback
        knockbackTimer = knockbackDuration;

        // Menambahkan gaya knockback pada musuh
        rb.AddForce(knockbackDirection * knockbackStrength, ForceMode2D.Impulse);
    }
}
