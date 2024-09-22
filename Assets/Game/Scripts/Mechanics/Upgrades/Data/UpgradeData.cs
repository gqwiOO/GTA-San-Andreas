using System;

namespace Game.Scripts.Mechanics.Upgrades
{
    [Serializable]
    public class UpgradeData
    {
        public UpgradeType UpgradeType;
        public int upgradeLevel;

        public UpgradeData(UpgradeType upgradeType, int upgradeLevel)
        {
            UpgradeType = upgradeType;
            this.upgradeLevel = upgradeLevel;
        }
    }
}