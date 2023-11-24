using System.Collections.Generic;

[System.Serializable]
public class ShopData
{
    public List<Skin> BoughtSkins = new List<Skin>();

    public ShopData(List<Skin> boughtSkins)
    {
        foreach (Skin skin in boughtSkins)
        {
            BoughtSkins.Add(skin);
        }
    }
}
