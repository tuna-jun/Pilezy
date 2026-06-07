using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] private Item itemPrefabs;
    [SerializeField] private Transform spawnRoot;
    [SerializeField] private int spawnCount;
    [SerializeField] private Vector3 spawnArea = new Vector3(3f, 2f, 3f);

    private void Start()
    {
        SpawnItems();
    }

    private void SpawnItems() 
    { 
        for ( int i  = 0; i < spawnCount; i++ )
        {
            Vector3 randomPosition = GetRandomSpawnPosition();
            Quaternion randomRotation = Random.rotation;

            Instantiate (itemPrefabs, randomPosition, randomRotation, spawnRoot);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float RandomX = Random.Range(-spawnArea.x, spawnArea.x);
        float RandomY = Random.Range(0f, spawnArea.y);
        float RandomZ = Random.Range(-spawnArea.z, spawnArea.z);

        return transform.position + new Vector3(RandomX, RandomY, RandomZ);
    }
}
