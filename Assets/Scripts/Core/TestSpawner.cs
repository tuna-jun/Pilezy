using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private Transform spawnRoot;
    [SerializeField] private Vector3 spawnArea = new Vector3(3f, 2f, 3f);

    private void Start()
    {
        SpawnItems();
    }

    private void SpawnItems() 
    { 
        for ( int i  = 0; i < levelData.SpawnItems.Count; i++ )
        {
            LevelItemEntry entry = levelData.SpawnItems[i];
           
            for(int j = 0; j < entry.Count; j++)
            {
                Vector3 randomPosition = GetRandomSpawnPosition();
                Instantiate(entry.ItemPrefab, randomPosition, Quaternion.identity, spawnRoot);
            }
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
