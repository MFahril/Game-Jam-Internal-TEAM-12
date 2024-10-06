using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirdropSpawner : MonoBehaviour
{
    public GameObject airdropPrefab;  
    public float spawnInterval = 30f;  
    public float spawnHeight = 10f;   
    public MapBounds mapBounds;        
    void Start()
    {
        InvokeRepeating("SpawnAirdrop", spawnInterval, spawnInterval);
    }

    void SpawnAirdrop()
    {
        if (mapBounds == null)
        {
            Debug.LogError("AirdropSpawner: MapBounds belum diatur!");
            return;
        }

        Vector2 spawnPosition = mapBounds.GetRandomSpawnPosition(spawnHeight);

        GameObject airdrop = Instantiate(airdropPrefab, spawnPosition, Quaternion.identity);

        Airdrop airdropComponent = airdrop.GetComponent<Airdrop>();
        if (airdropComponent != null)
        {
            airdropComponent.SetTargetPosition(mapBounds.GetRandomTargetPosition());
        }
        else
        {
            Debug.LogError("Komponen 'Airdrop' tidak ditemukan di prefab airdrop!");
        }
    }
}
