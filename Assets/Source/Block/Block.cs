using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _crashParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMoverView player))
        {
            player.Crash();
            AudioManager.Instance.Play("StoneCrash");
            Instantiate(_crashParticle.gameObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
