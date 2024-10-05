using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public TimerUI timerUI;
    public Transform playerTransform; // Referensi ke pemain
    public float enemyMoveSpeed = 3f; // Field untuk mengatur kecepatan musuh
    private int currentWave = 1;
    private int enemiesPerWave = 1;
    private float speedIncreaseInterval = 30f; // Interval 30 detik
    private float maxSpeed = 5f; // Kecepatan maksimum
    private float nextSpeedIncreaseTime = 30f; // Waktu saat kecepatan bertambah

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int enemiesAlive = FindObjectsOfType<EnemyData>().Length; // Menghitung musuh yang ada

            // Spawn musuh jika jumlah musuh kurang dari jumlah yang ditentukan untuk wave
            if (enemiesAlive < enemiesPerWave)
            {
                int spawnIndex = Random.Range(0, spawnPoints.Length);
                GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);

                // Menambahkan komponen EnemyData dan mengatur referensi pemain serta kecepatan musuh
                EnemyData enemyData = enemyInstance.AddComponent<EnemyData>();
                enemyData.playerTransform = playerTransform;
                enemyData.moveSpeed = enemyMoveSpeed; // Mengatur kecepatan musuh

                enemiesAlive++;
            }

            // Periksa apakah sudah waktunya untuk menambah kecepatan
            float elapsedTime = timerUI.ElapsedTime;
            if (elapsedTime >= nextSpeedIncreaseTime && enemyMoveSpeed < maxSpeed)
            {
                enemyMoveSpeed += 1f; // Tambah kecepatan 1
                nextSpeedIncreaseTime += speedIncreaseInterval; // Set waktu berikutnya
                enemyMoveSpeed = Mathf.Clamp(enemyMoveSpeed, 0, maxSpeed); // Jangan melebihi kecepatan maksimum
            }

            // Periksa apakah waktu sudah mencapai gelombang baru
            if (elapsedTime >= currentWave * 10)
            {
                currentWave++;
                enemiesPerWave = currentWave;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}

public class EnemyData : MonoBehaviour
{
    public float moveSpeed; // Kecepatan musuh
    public Transform playerTransform;

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            // Hanya bergerak jika jarak ke pemain lebih besar dari threshold
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance > 0.5f) // Ambang batas untuk menghindari musuh 'melompat' ke pemain
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
        }
    }
}
