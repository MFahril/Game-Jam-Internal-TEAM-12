using UnityEngine;
using UnityEngine.UI; // Untuk Scrollbar

public class PlayerHealthBar : MonoBehaviour
{
    public Stats playerStats;    // Referensi ke komponen Stats pemain
    public Scrollbar healthBar;  // Referensi ke Scrollbar untuk health bar

    // Update health bar berdasarkan nilai kesehatan saat ini
    public void UpdateHealthBar()
    {
        // Update nilai scrollbar berdasarkan health pemain
        healthBar.size = Mathf.Clamp01((float)playerStats.health / playerStats.maxHealth);
    }
}
