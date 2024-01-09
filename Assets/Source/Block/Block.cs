using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _crashParticle;

    private Vector3 _spawnPosition;
    private Quaternion _spawnRotation;

    private void OnCollisionEnter(Collision collision)
    {
        //_spawnPosition = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        //_spawnRotation = new Quaternion(transform.rotation.x -50f, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        if (collision.gameObject.TryGetComponent(out PlayerMoverView player))
        {
            player.Crash();
            Instantiate(_crashParticle.gameObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
