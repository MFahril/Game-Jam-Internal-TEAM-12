using UnityEngine;

public class EnemyBody : MonoBehaviour
{
<<<<<<< Updated upstream
	public GameObject player;
	public void Update()
	{
		if (this.GetComponent<Stats>().health <= 0)
		{
			Destroy(this.gameObject);
		}
	}
=======
    public GameObject player;
    private Stats enemyStats;

    void Start()
    {
        // Inisialisasi komponen Stats pada enemy
        enemyStats = GetComponent<Stats>();
        if (enemyStats == null)
        {
            Debug.LogError("Stats component not found on the enemy!");
        }

        // Pastikan player juga diinisialisasi dengan benar
        if (player == null)
        {
            Debug.LogError("Player GameObject not assigned to the enemy!");
        }
    }

    void Update()
    {
        if (enemyStats != null && enemyStats.health <= 0)
        {
            Destroy(gameObject); // Hancurkan enemy ketika health <= 0

            // Pastikan GameManager instance tidak null sebelum mengaksesnya
            if (GameManager.Instance != null)
            {
                GameManager.Instance.killCounter++; // Tambahkan kill counter di GameManager
                Debug.Log("Kill Counter: " + GameManager.Instance.killCounter);
            }
            else
            {
                Debug.LogError("GameManager Instance is not set!");
            }
        }
    }
>>>>>>> Stashed changes
}
