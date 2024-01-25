using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected ParticleSystem ExplosionParticle;

    protected float Resourses;
    protected MeshRenderer Mesh;

    private void Start()
    {
        ExplosionParticle = GetComponentInChildren<ParticleSystem>();
        Mesh = GetComponentInChildren<MeshRenderer>();
    }

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerView playerView))
        {
            GetResourses(playerView);
            Mesh.enabled = false;
            ExplosionParticle!.Play();
            Invoke("Destroy", 1f);
        }
    }

    protected virtual void GetResourses(PlayerView playerView) { }
    
    protected void Destroy()
    {
        Destroy(gameObject);
    }
}
