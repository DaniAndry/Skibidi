using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _crashParticle;

    private Celling _celling;

    private void Awake()
    {
        _celling = GetComponentInChildren<Celling>();
    }

    protected void OnCollisionEnter(Collision collision)
    {
        Activate(collision);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Chuchpan chuchpan))
        {
            Instantiate(_crashParticle.gameObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    protected virtual void Activate(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMoverView player))
        {
            DisableCelling();
            player.Crash();
            AudioManager.Instance.Play("StoneCrash");
            Instantiate(_crashParticle.gameObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void DisableCelling()
    {
        _celling.gameObject.SetActive(false);
    }
}