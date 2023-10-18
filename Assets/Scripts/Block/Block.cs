using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Crash();
            gameObject.gameObject.SetActive(false);
        }
    }
}
