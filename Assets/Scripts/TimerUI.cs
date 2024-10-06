using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private bool isRunning = true; // Flag untuk mengontrol apakah timer berjalan

    public float ElapsedTime
    {
        get { return elapsedTime; }
    }

    void Update()
    {
        if (isRunning) // Cek apakah timer berjalan
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StopTimer()
    {
        isRunning = false; // Menghentikan timer
    }
}
