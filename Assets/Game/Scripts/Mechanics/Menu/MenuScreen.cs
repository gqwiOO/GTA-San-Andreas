using System;
using Game.Scripts.Const;
using Game.Scripts.Mechanics.Screen;
using Game.Scripts.Mechanics.UI;
using Game.Scripts.Mechanics.Upgrades.View;
using Game.Scripts.Services.SceneLoader;
using Game.Scripts.Services.ScreenService;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Mechanics.Menu
{
    public class MenuScreen: UIScreen
    {
        [SerializeField] private UIButton PlayButton;
        [SerializeField] private UIButton UpgradeButton;
        private ISceneLoader _sceneLoader;
        private IScreenService _screenService;

        [Inject]
        private void Construct(ISceneLoader sceneLoader, IScreenService screenService)
        {
            _screenService = screenService;
            _sceneLoader = sceneLoader;
        }
        private void Start()
        {
            PlayButton.OnClick += LoadGameplayScene_OnClick;
            UpgradeButton.OnClick += EnterUpgrade_OnClick;
        }

        private void OnDestroy()
        {
            PlayButton.OnClick -= LoadGameplayScene_OnClick;
            UpgradeButton.OnClick -= EnterUpgrade_OnClick;
        }

        private void EnterUpgrade_OnClick() => _screenService.Show<UpgradeScreen>();

        private void LoadGameplayScene_OnClick() => _sceneLoader.Load(Constants.GameplaySceneName);
    }
}