using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private List<Block> _blocks;

    private Dictionary<Chunk, List<GameObject>> _spawnedBlocks = new Dictionary<Chunk, List<GameObject>>();

    private int _minCount = 5;
    private int _maxCount = 10;

    public void SpawnBlocks(Chunk chunk)
    {
        int count = GetCountToSpawn();
        Vector3 transform;

        if (!_spawnedBlocks.ContainsKey(chunk))
        {
            _spawnedBlocks[chunk] = new List<GameObject>();
        }

        for (int i = 0; i < count; i++)
        {
            do
            {
                transform = GetRandomSpawnPosition(chunk);
            }

            while (CheckCollision(transform));

            Block block = SelectBlock();
            GameObject blockObj = Instantiate(block.gameObject, transform, Quaternion.identity);
            _spawnedBlocks[chunk].Add(blockObj);
        }
    }

    public void RemoveBlocks(Chunk chunk)
    {
        if (_spawnedBlocks.ContainsKey(chunk))
        {
            foreach (GameObject block in _spawnedBlocks[chunk])
            {
                Destroy(block);
            }
            _spawnedBlocks[chunk].Clear();
        }
    }

    private bool CheckCollision(Vector3 position)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, 0.5f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.GetComponent<Item>())
            {
                return true;
            }
        }
        return false;
    }

    private Block SelectBlock()
    {
        Block block = _blocks[Random.Range(0, _blocks.Count)];
        return block;
    }

    private int GetCountToSpawn()
    {
        return Random.Range(_minCount, _maxCount);
    }

    private Vector3 GetRandomSpawnPosition(Chunk chunk)
    {
        Collider chunkCollider = chunk.GetComponent<Collider>();
        Bounds bounds = chunkCollider.bounds;
        Vector3 chunkCenter = chunk.transform.position;
        Vector3 extents = bounds.extents;

        float randomX = chunkCenter.x + Random.Range(-0.5f, 0.5f);
        float randomY = chunkCenter.y + 0.2f;
        float randomZ = chunkCenter.z + Random.Range(-extents.z, extents.z);

        return new Vector3(randomX, randomY, randomZ);
    }
}
