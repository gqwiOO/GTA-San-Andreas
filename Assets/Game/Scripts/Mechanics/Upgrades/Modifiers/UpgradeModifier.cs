using Game.Scripts.Mechanics.Upgrades.Config;
using Game.Scripts.Mechanics.Upgrades.Model;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Mechanics.Upgrades.Modifiers
{
    public class UpgradeModifier : MonoBehaviour
    {
        private UpgradeModel _upgradeModel;
        private UpgradesConfig _upgradesConfig;

        [Inject]
        private void Construct(UpgradeModel upgradeModel, UpgradesConfig upgradesConfig)
        {
            _upgradesConfig = upgradesConfig;
            _upgradeModel = upgradeModel;
        }
        
        public float Modify(UpgradeType upgradeType, float startValue)
        {
            var level = _upgradeModel.GetLevel(upgradeType);
            var start = startValue;
            
            for (int i = 0; i < level; i++)
            {
                start += start * _upgradesConfig.percentOfValueByUpgradeLevel[upgradeType];
            }
            return start;
        }
    }
}