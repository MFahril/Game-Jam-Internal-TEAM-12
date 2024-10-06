using UnityEngine;
using UnityEngine.UI; // Digunakan untuk Scrollbar

public class BossHealthBar : MonoBehaviour
{
    public Scrollbar healthBar;   // Referensi ke Scrollbar untuk health bar boss

    private BossData bossData;    // Referensi ke BossData

    // Mengatur referensi ke boss yang health bar-nya akan diperbarui
    public void SetBoss(BossData boss)
    {
        bossData = boss;
    }

    // Memperbarui health bar berdasarkan kesehatan boss
    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (healthBar != null)
        {
            // Update scrollbar size berdasarkan kesehatan boss
            healthBar.size = Mathf.Clamp01((float)currentHealth / maxHealth);
        }
    }
}
