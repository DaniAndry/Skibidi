using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> itemPrefabs = new List<GameObject>();
    [SerializeField] private ChunksPlacer chunksPlacer;
    [SerializeField] private PlayerView _player;

    private Dictionary<Chunk, List<GameObject>> spawnedItems = new Dictionary<Chunk, List<GameObject>>();

    private void Awake()
    {
        foreach (var chunk in chunksPlacer.Chunks)
        {
            chunk.Spawned += OnChunkSpawned;
            chunk.Deactivated += OnChunkDeactivated;
        }
    }

    private void OnDisable()
    {
        foreach (var chunk in chunksPlacer.Chunks)
        {
            chunk.Spawned -= OnChunkSpawned;
            chunk.Deactivated -= OnChunkDeactivated;
        }
    }

    private void OnChunkSpawned(Chunk chunk)
    {
        if (itemPrefabs.Count == 0) return;

        GameObject randomItemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Count)];
        Vector3 spawnPosition = GetRandomPositionOnChunk(chunk);
        GameObject spawnedItem = Instantiate(randomItemPrefab, spawnPosition, Quaternion.identity);

        if (!spawnedItems.ContainsKey(chunk))
            spawnedItems[chunk] = new List<GameObject>();

        spawnedItems[chunk].Add(spawnedItem);
    }

    private void OnChunkDeactivated(Chunk chunk)
    {
        if (!spawnedItems.ContainsKey(chunk)) return;

        foreach (var item in spawnedItems[chunk])
            Destroy(item);

        spawnedItems[chunk].Clear();
    }

    private Vector3 GetRandomPositionOnChunk(Chunk chunk)
    {
        Collider chunkCollider = chunk.GetComponent<Collider>();

        if (chunkCollider == null)
        {
            Debug.LogError("Chunk does not have a Collider component!");
            return Vector3.zero;
        }

        Bounds bounds = chunkCollider.bounds;
        Vector3 chunkCenter = chunk.transform.position;
        Vector3 extents = bounds.extents;

        float randomX = chunkCenter.x + Random.Range(-extents.x, extents.x);
        float randomY = bounds.max.y + 0.3f; 
        
        return new Vector3(randomX, randomY, _player.transform.position.z +5);
    }

}
