using System.Collections.Generic;
using UnityEngine;

public class ChunksPlacer : MonoBehaviour
{
    [SerializeField] private Chunk[] _chunks;
    [SerializeField] private Chunk _firstChunk;

    private Transform _player;
    private List<Chunk> _disabledChunks = new List<Chunk>();
    private List<Chunk> _spawnedChunks = new List<Chunk>();
    private int _spawnLenght = 40;

    public Chunk[] Chunks => _chunks;

    private void Start()
    {
        _spawnedChunks.Add(_firstChunk);
    }

    private void Update()
    {
        if (_player.position.z > _spawnedChunks[_spawnedChunks.Count - 1].End.transform.position.z - _spawnLenght && _player != null)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        foreach (Chunk chunk in _chunks)
        {
            if (chunk.gameObject.activeSelf == false)
            {
                _disabledChunks.Add(chunk);
            }
        }

        Chunk newChunk = _disabledChunks[Random.Range(0, _disabledChunks.Count)];

        foreach (Chunk chunk in _chunks)
        {
            if (chunk.gameObject.activeSelf == false)
            {
                _disabledChunks.Remove(chunk);
            }
        }

        newChunk.gameObject.SetActive(true);
        float position = _spawnedChunks[_spawnedChunks.Count - 1].transform.localScale.z;
        newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].transform.position;
        newChunk.transform.position += new Vector3(0, 0, position);

        _spawnedChunks.Add(newChunk);

        if (_spawnedChunks.Count == 3)
            DisableChunks();
    }

    private void DisableChunks()
    {
        for (int i = 0; i < _spawnedChunks.Count - 1; i++)
        {
            _spawnedChunks[i].gameObject.SetActive(false);
            _spawnedChunks.Remove(_spawnedChunks[i]);
        }
    }

    public void GetPlayerTransform(Transform player)
    {
        _player = player;
    }
}
