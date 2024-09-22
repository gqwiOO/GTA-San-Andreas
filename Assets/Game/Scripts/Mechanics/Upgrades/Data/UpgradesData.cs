using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Scripts.Mechanics.Upgrades.Data
{
    [Serializable]
    public class UpgradesData
    {
        public List<UpgradeData> upgrades;

        public UpgradesData(List<UpgradeData> upgrades)
        {
            this.upgrades = upgrades;
        }

        public int GetLevel(UpgradeType upgradeType) =>
            upgrades.FirstOrDefault(upgrade => upgrade.UpgradeType == upgradeType)!.upgradeLevel;
        
        public UpgradeData GetUpgrade(UpgradeType upgradeType) =>
            upgrades.FirstOrDefault(upgrade => upgrade.UpgradeType == upgradeType);
    }
}