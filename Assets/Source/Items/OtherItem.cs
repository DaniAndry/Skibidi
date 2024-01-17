using UnityEngine;

public class OtherItem : Item
{
    public string itemType; 

    private ItemViewSpawner _spawner;

    protected override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerView player))
        {
            Destroy(gameObject);
            _spawner.Spawn(this);
        }
    }

    protected void UseBonus()
    {
        
    }

    public void Init(ItemViewSpawner spawwner)
    {
        _spawner = spawwner;
    }
}