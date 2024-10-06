using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public TimerUI timerUI;
    public Stats playerStats;
    public GameObject gameOverUI;

    void Start()
    {
        gameOverUI.SetActive(false); // Menyembunyikan UI Game Over di awal
    }

    void Update()
    {
        // Periksa apakah kesehatan pemain <= 0
        if (playerStats.health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        timerUI.StopTimer(); // Menghentikan timer
        gameOverUI.SetActive(true); // Menampilkan UI Game Over
        Time.timeScale = 0f; // Menghentikan semua aktivitas di game
    }
}
