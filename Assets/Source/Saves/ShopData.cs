using System.Collections.Generic;

[System.Serializable]
public class ShopData
{
    public PlayerView PlayerSkin;
    public List<Skin> BoughtSkins = new List<Skin>();

    public ShopData(Shop shop)
    {
        PlayerSkin = shop.CurrentPlayerSkin;

        foreach (Skin skin in BoughtSkins)
        {
            BoughtSkins.Remove(skin);
        }

        foreach (Skin skin in shop.BoughtSkins)
        {
            BoughtSkins.Add(skin);
        }
    }
}
