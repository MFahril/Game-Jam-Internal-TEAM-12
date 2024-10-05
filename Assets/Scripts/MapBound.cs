using UnityEngine;

public class MapBounds : MonoBehaviour
{
    private BoxCollider2D mapCollider;

    private void Awake()
    {
        mapCollider = GetComponent<BoxCollider2D>();
        if (mapCollider == null)
        {
            Debug.LogError("MapBounds: GameObject ini harus memiliki BoxCollider2D.");
        }
    }

    //Posisi Random Spawn
    public Vector2 GetRandomSpawnPosition(float spawnHeight)
    {
        float minX = mapCollider.bounds.min.x;
        float maxX = mapCollider.bounds.max.x;

        float randomX = Random.Range(minX, maxX);

        return new Vector2(randomX, spawnHeight);
    }

    public Vector2 GetRandomTargetPosition()
    {
        float minX = mapCollider.bounds.min.x;
        float maxX = mapCollider.bounds.max.x;
        float minY = mapCollider.bounds.min.y;
        float maxY = mapCollider.bounds.max.y;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }
}
