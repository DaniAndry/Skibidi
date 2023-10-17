using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    public void TakeResourses(int count)
    {

    }

    public void Crashed()
    {
        _mover.ChangeSpeed();
    }
}
