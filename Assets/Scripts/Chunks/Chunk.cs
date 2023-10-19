using UnityEngine;
using UnityEngine.Events;

public class Chunk : MonoBehaviour
{
    public event UnityAction<Chunk> Spawned;
    public event UnityAction<Chunk> Deactivated;

    private BeginPoint _begin;
    private EndPoint _end;

    public BeginPoint Begin => _begin;
    public EndPoint End => _end;

    private void Awake()
    {
        _begin = GetComponentInChildren<BeginPoint>();
        _end = GetComponentInChildren<EndPoint>();
    }

    private void OnEnable()
    {
        Spawned?.Invoke(this);
    }

    private void OnDisable()
    {
        Deactivated?.Invoke(this);
    }
}
