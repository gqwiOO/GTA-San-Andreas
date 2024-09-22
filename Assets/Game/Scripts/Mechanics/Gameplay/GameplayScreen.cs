using Game.Scripts.Mechanics.Screen;
using Game.Scripts.Mechanics.UI;
using Game.Scripts.Mechanics.Upgrades.View;
using Game.Scripts.Services.ScreenService;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Mechanics.Gameplay
{
    public class GameplayScreen: UIScreen
    {
        [SerializeField] private UIButton upgradeButton;
        private IScreenService _screenService;

        [Inject]
        private void Construct(IScreenService screenService)
        {
            _screenService = screenService;
        }
        
        private void Start() => upgradeButton.OnClick += ShowUpgrade_OnClick;
        private void ShowUpgrade_OnClick() => _screenService.Show<UpgradeScreen>(false);
        private void OnDestroy() => upgradeButton.OnClick -= ShowUpgrade_OnClick;
    }
}