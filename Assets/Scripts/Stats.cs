using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxHealth = 20;  // Kesehatan maksimum
    public int health;          // Kesehatan saat ini
    public int damage = 1;      // Besar damage yang diberikan oleh entitas ini

    void Start()
    {
        // Pastikan health saat mulai adalah maksimum
        health = maxHealth;
    }

    // Metode untuk menerima damage
    public void TakeDamage(int amount)
    {
        health -= amount;

        // Pastikan health tidak kurang dari 0
        if (health <= 0)
        {
            health = 0; // Untuk mencegah nilai health negatif
            Die();      // Panggil metode kematian
        }
    }

    // Metode untuk penyembuhan jika diperlukan
    public void Heal(int amount)
    {
        health += amount;

        // Pastikan health tidak melebihi maxHealth
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    // Metode yang akan dipanggil ketika health mencapai 0
    void Die()
    {
        // Logika kematian, seperti menghancurkan objek atau memicu animasi kematian
        Destroy(gameObject);
    }
}
