using System;
using Game.Scripts.Mechanics.Screen;
using Game.Scripts.Mechanics.UI;
using UnityEngine;

namespace Game.Scripts.Mechanics.Upgrades.View
{
    public class UpgradeScreen: UIScreen
    {
        [SerializeField] private UIButton backButton;

        protected override void StartHook() => backButton.OnClick += Hide;
        protected override void OnDestroyHook() => backButton.OnClick -= Hide;
    }
}