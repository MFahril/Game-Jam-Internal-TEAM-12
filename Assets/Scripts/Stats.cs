using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health = 20; // Set health player
    public int damage = 1;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }

<<<<<<< Updated upstream
    void Die()
    {
=======
        // Memperbarui UI health bar
        FindObjectOfType<PlayerHealthBar>().UpdateHealthBar();
    }

    // Metode yang akan dipanggil ketika health mencapai 0
    void Die()
    {
        // Logika kematian
>>>>>>> Stashed changes
        Destroy(gameObject);
    }
}
