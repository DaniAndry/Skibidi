using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected ParticleSystem ExplosionParticle;

    protected float Resourses;
    protected MeshRenderer Mesh;
    protected PlayerView PlayerView;
    protected PlayerMoverView PlayerMoverView;

    private void Start()
    {
        ExplosionParticle = GetComponentInChildren<ParticleSystem>();
        Mesh = GetComponentInChildren<MeshRenderer>();
    }

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerView playerView))
        {
            PlayerView = playerView;
            GetResourses(PlayerView);
            StartDestroy();
        }
        if (collision.gameObject.TryGetComponent(out PlayerMoverView playerMoverView))
        {
            PlayerMoverView = playerMoverView;
            GetMoverResourses(PlayerMoverView);
            StartDestroy();
        }
    }

    protected virtual void GetResourses(PlayerView playerView) { }

    protected virtual void GetMoverResourses(PlayerMoverView playerMoverView) { }

    private void StartDestroy()
    {
        Mesh.enabled = false;
        ExplosionParticle!.Play();
        Invoke("Destroy", 1f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
