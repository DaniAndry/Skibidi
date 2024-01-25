using UnityEngine;

public class OtherItem : Item
{
    public string itemType;

    private ItemViewSpawner _spawner;

    protected override void OnTriggerEnter(Collider collision)
    {
        base.OnTriggerEnter(collision);
        _spawner.Spawn(this);

    }

    public void Init(ItemViewSpawner spawwner)
    {
        _spawner = spawwner;
    }
}