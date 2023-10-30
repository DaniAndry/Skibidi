public class EnergyItem : Item
{
    protected float Energy = 10;

    protected override void GetResourses(PlayerView playerView)
    {
        playerView.OnEnergyChanged(Energy);
    }
}
