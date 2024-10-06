using System.Collections; // Diperlukan untuk IEnumerator
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossPrefab; // Prefab untuk mini boss
    public Transform[] spawnPoints;
    public TimerUI timerUI;
    public Transform playerTransform;
    public float enemyMoveSpeed = 3f;
    private int currentWave = 1;
    private int enemiesPerWave = 1;
    private float speedIncreaseInterval = 30f;
    private float maxSpeed = 5f;
    private float nextSpeedIncreaseTime = 30f;

    public float bossSpawnInterval = 60f; // Waktu untuk spawn boss dalam detik
    public bool bossAlive = false; // Status untuk memeriksa apakah boss masih hidup
    private float nextBossSpawnTime = 60f; // Waktu untuk spawn boss

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (!bossAlive) // Cek apakah boss masih hidup
            {
                int enemiesAlive = FindObjectsOfType<EnemyData>().Length;

                if (enemiesAlive < enemiesPerWave)
                {
                    int spawnIndex = Random.Range(0, spawnPoints.Length);
                    GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);

                    EnemyData enemyData = enemyInstance.GetComponent<EnemyData>();
                    enemyData.playerTransform = playerTransform;
                    enemyData.moveSpeed = enemyMoveSpeed;

                    enemiesAlive++;
                }

                float elapsedTime = timerUI.ElapsedTime;
                if (elapsedTime >= nextSpeedIncreaseTime && enemyMoveSpeed < maxSpeed)
                {
                    enemyMoveSpeed += 1f;
                    nextSpeedIncreaseTime += speedIncreaseInterval;
                    enemyMoveSpeed = Mathf.Clamp(enemyMoveSpeed, 0, maxSpeed);
                }

                if (elapsedTime >= currentWave * 10)
                {
                    currentWave++;
                    enemiesPerWave = currentWave;
                }
            }
            else
            {
                yield return null; // Tunggu sampai boss mati
            }

            // Spawn boss setiap bossSpawnInterval menit
            if (timerUI.ElapsedTime >= nextBossSpawnTime)
            {
                SpawnBoss();
                nextBossSpawnTime += bossSpawnInterval; // Atur waktu spawn boss berikutnya
            }

            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnBoss()
    {
        if (FindObjectOfType<BossData>() == null)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject bossInstance = Instantiate(bossPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
            bossInstance.GetComponent<BossData>().playerTransform = playerTransform; // Set playerTransform untuk boss
            bossAlive = true; // Set status bossAlive
        }
    }
}
