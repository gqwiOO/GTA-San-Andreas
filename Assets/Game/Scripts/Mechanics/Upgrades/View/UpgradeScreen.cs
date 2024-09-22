using System;
using Game.Scripts.Mechanics.Screen;
using Game.Scripts.Mechanics.UI;
using UnityEngine;

namespace Game.Scripts.Mechanics.Upgrades.View
{
    public class UpgradeScreen: UIScreen
    {
        [SerializeField] private UIButton backButton;

        private void Start() => backButton.OnClick += Hide;
        private void OnDestroy() => backButton.OnClick -= Hide;
    }
}