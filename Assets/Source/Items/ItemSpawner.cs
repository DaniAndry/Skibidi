using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemPrefabs = new List<GameObject>();
    [SerializeField] private ChunksPlacer _chunksPlacer;
    [SerializeField] private PlayerView _player;
    [SerializeField] private BoostItemFactory _boostItemFactory;
    [SerializeField] private OtherItemFactory _otherItemFactory;

    private Dictionary<Chunk, List<GameObject>> spawnedItems = new Dictionary<Chunk, List<GameObject>>();

    private void Awake()
    {
        foreach (var chunk in _chunksPlacer.Chunks)
        {
            chunk.Spawned += OnChunkSpawned;
            chunk.Deactivated += OnChunkDeactivated;
        }
    }

    private void OnDisable()
    {
        foreach (var chunk in _chunksPlacer.Chunks)
        {
            chunk.Spawned -= OnChunkSpawned;
            chunk.Deactivated -= OnChunkDeactivated;
        }
    }

    private void OnChunkSpawned(Chunk chunk)
    {
        if (_itemPrefabs.Count == 5) return;

        GameObject randomItemPrefab = _itemPrefabs[Random.Range(0, _itemPrefabs.Count)];
        ItemFactory factory = ChooseFactory(randomItemPrefab);
        GameObject spawnedItem = factory.CreateItem(randomItemPrefab, chunk, _player);

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

    private ItemFactory ChooseFactory(GameObject prefab)
    {
        if (prefab.GetComponent<OtherItem>() != null)
        {
            return _otherItemFactory;
        }
        else
        {
            return _boostItemFactory;
        }
    }
}