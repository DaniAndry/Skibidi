using UnityEngine;
using UnityEngine.Events;

public class Chunk : MonoBehaviour
{
    public event UnityAction<Chunk> Spawned;
    public event UnityAction<Chunk> Deactivated;

    public BeginPoint Begin { get; private set; }
    public EndPoint End { get; private set; }
    public LenghtChunk LenghChunk { get; private set; }
   
    private void OnEnable()
    {
        Spawned?.Invoke(this);
    }

    private void Awake()
    {
        Begin = GetComponentInChildren<BeginPoint>();
        End = GetComponentInChildren<EndPoint>();
        LenghChunk = GetComponentInChildren<LenghtChunk>();
    }

    private void OnDisable()
    {
        Deactivated?.Invoke(this);
    }
}
