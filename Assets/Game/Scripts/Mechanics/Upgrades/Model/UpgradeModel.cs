using System;
using System.Collections.Generic;
using Game.Scripts.Const;
using Game.Scripts.Mechanics.Upgrades.Data;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Mechanics.Upgrades.Model
{
    public class UpgradeModel: IInitializable 
    {
        private UpgradesData upgradesData;

        public event Action<UpgradeType> OnUpgraded; 

        public void Initialize() => LoadData();

        private void LoadData()
        {
            if (!PlayerPrefs.HasKey(KeySave.UpgradesData.ToString()))
            {
                SetDefaultData();
                Save();
            }
            else
                LoadPrefsData();
        }

        private void LoadPrefsData() => upgradesData = JsonUtility.FromJson<UpgradesData>(PlayerPrefs.GetString(KeySave.UpgradesData.ToString()));
        private void Save() => PlayerPrefs.SetString(KeySave.UpgradesData.ToString(),JsonUtility.ToJson(upgradesData));

        private void SetDefaultData()
        {
            upgradesData = new UpgradesData(new List<UpgradeData>()
            {
                new UpgradeData(UpgradeType.Health,0),
                new UpgradeData(UpgradeType.MeleeAttack    ,0),
                new UpgradeData(UpgradeType.RangeAttack,0),
            });
        }

        public void Upgrade(UpgradeType upgradeType, int level = 1)
        {
            upgradesData.GetUpgrade(upgradeType).upgradeLevel += level;
            Save();
            OnUpgraded?.Invoke(upgradeType);
        }

        public int GetLevel(UpgradeType upgradeType) => upgradesData.GetLevel(upgradeType);
    }
}