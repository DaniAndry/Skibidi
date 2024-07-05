using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;
        public int Money = 50000;
        public int Diamond = 5000;
        public float MaxEnergy = 50;
        public float Record = 0;
        public int CountEnergyBoost = 0;
        public int CountUpgradeEnergyBoost = 1;
        public int CountSpeedBoost = 0;
        public int CountUpgradeSpeedBoost = 1;
        public int CountMoneyBoost = 0;
        public int CountUpgradeMoneyBoost = 1;
        public float VolumeSound = 0.5f;
        public List<Skin> BoughtSkins;
        public Skin SelectedSkin;
        public List<Dance> BoughtDances;
        public Dance SelectedDance;
        public List<float> AmountDailyProgreses;
        public List<float> AmountWeeklyProgreses;
        public List<float> AmountDistanceProgreses;
        public int StartWeeklyTime;
        public int StartDailyTime;
        public float WorldSound = 0.5f;

        public SavesYG()
        {
        }
    }
}

