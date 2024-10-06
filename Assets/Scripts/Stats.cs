using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxHealth = 100;  // Kesehatan maksimal
    public int health;            // Kesehatan saat ini
    public int damage = 1;        // Damage yang diberikan oleh musuh atau pemain

    void Start()
    {
        health = maxHealth; // Atur kesehatan awal menjadi maksimal
    }

    public void TakeDamage(int amount)
    {
        health -= amount; // Kurangi kesehatan
        health = Mathf.Max(health, 0); // Pastikan kesehatan tidak negatif

        if (health <= 0)
        {
            Die(); // Panggil metode mati jika kesehatan mencapai 0
        }
    }

<<<<<<< Updated upstream
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
=======
    void Die()
    {
        Destroy(gameObject); // Hancurkan objek ini ketika mati
>>>>>>> Stashed changes
    }
}
