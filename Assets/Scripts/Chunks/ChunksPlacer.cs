using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksPlacer : MonoBehaviour
{
    [SerializeField] private Chunk[] _chunks;
    [SerializeField] private Player _player;
    [SerializeField] private Chunk _firstChunk;

    private List<Chunk> _disabledChunks = new List<Chunk>();
    private List<Chunk> _spawnedChunks = new List<Chunk>();
    private int _spawnLenght = 4;

    private void Start()
    {
        _spawnedChunks.Add(_firstChunk);
    }

    private void Update()
    {
        if (_player.transform.position.z > _spawnedChunks[_spawnedChunks.Count - 1].End.transform.position.z - _spawnLenght)
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
        newChunk.transform.position += new Vector3(0,0, position);

        _spawnedChunks.Add(newChunk);

        if (_spawnedChunks.Count == 3)
            DisableChunks();
    }

    private void DisableChunks()
    {
        for(int i = 0; i < _spawnedChunks.Count - 1; i++)
        {
            _spawnedChunks[i].gameObject.SetActive(false);
            _spawnedChunks.Remove(_spawnedChunks[i]);
        }
    }
}
