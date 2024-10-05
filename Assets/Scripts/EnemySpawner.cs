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

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int enemiesAlive = FindObjectsOfType<EnemyData>().Length; // Menghitung musuh yang ada

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

            int elapsedTime = Mathf.FloorToInt(timerUI.ElapsedTime);
            if (elapsedTime >= currentWave * 20)
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
