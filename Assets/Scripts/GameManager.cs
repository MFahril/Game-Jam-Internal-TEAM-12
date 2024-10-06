using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    // Counter untuk jumlah musuh yang dibunuh
    public int killCounter = 0;

    void Awake()
    {
        // Periksa jika instance sudah ada, jika ada, hancurkan duplikatnya
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Agar GameManager tidak dihancurkan ketika scene berubah
        }
    }
}
