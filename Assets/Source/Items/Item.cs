using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected ParticleSystem ExplosionParticle;

    protected float Resourses;

    private void Start()
    {
        ExplosionParticle = GetComponentInChildren<ParticleSystem>();
    }

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerView playerView))
        {
            GetResourses(playerView);
            Invoke("Destroy", 1f);
        }
    }

    protected virtual void GetResourses(PlayerView playerView) { }
    
    protected void Destroy()
    {
        Destroy(gameObject);
    }
}
