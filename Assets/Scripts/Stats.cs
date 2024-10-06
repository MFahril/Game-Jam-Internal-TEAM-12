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
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
