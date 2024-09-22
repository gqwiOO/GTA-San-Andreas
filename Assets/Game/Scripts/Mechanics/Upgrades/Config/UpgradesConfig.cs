using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Mechanics.Upgrades.Config
{
    [CreateAssetMenu(menuName = "UpgradesConfig", fileName = "UpgradesConfig", order = 0)]
    public class UpgradesConfig: SerializedScriptableObject
    {
        [DictionaryDrawerSettings(KeyLabel = "Upgrade", ValueLabel = "Percent")]
        public Dictionary<UpgradeType, float> percentOfValueByUpgradeLevel;
    }
}