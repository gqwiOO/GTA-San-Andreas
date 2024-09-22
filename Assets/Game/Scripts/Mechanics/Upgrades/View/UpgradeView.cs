using System;
using Game.Scripts.Mechanics.UI;
using Game.Scripts.Mechanics.Upgrades.Model;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Mechanics.Upgrades.View
{
    public class UpgradeView: MonoBehaviour
    {
        [SerializeField] private UpgradeType upgradeType;
        
        [SerializeField] private TextMeshProUGUI currentLevel;
        [SerializeField] private UIButton upgradeButton;
        
        private UpgradeModel _upgradeModel;

        [Inject]
        private void Construct(UpgradeModel upgradeModel)
        {
            _upgradeModel = upgradeModel;
        }

        private void Start()
        {
            UpdateView(upgradeType);
            _upgradeModel.OnUpgraded += UpdateView;
            upgradeButton.OnClick += Upgrade;
        }

        private void Upgrade() => _upgradeModel.Upgrade(upgradeType);

        private void UpdateView(UpgradeType type)
        {
            if (type != upgradeType)
                return;
            currentLevel.text = _upgradeModel.GetLevel(type).ToString();
        }

        private void OnDestroy()
        {
            _upgradeModel.OnUpgraded -= UpdateView;
            upgradeButton.OnClick -= Upgrade;
        }
    }
}