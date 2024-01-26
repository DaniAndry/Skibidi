using UnityEngine;

public class OtherItem : Item
{
    public string itemType;

    private ItemViewSpawner _spawner;

    protected override void OnTriggerEnter(Collider collision)
    {
        _spawner.Spawn(this);
        base.OnTriggerEnter(collision);
    }

    public virtual void Boost()
    { }

    public virtual void DeBoost()
    { }

    public void Init(ItemViewSpawner spawwner)
    {
        _spawner = spawwner;
    }
}