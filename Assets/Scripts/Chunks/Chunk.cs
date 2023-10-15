using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    private BeginPoint _begin;
    private EndPoint _end;

    public BeginPoint Begin => _begin;
    public EndPoint End => _end;

    private void Awake()
    {
        _begin = GetComponentInChildren<BeginPoint>();
        _end = GetComponentInChildren<EndPoint>();
    }
}
