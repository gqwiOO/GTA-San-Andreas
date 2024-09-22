using Game.Scripts.Const;
using Game.Scripts.Mechanics.Screen;
using Game.Scripts.Mechanics.UI;
using Game.Scripts.Mechanics.Upgrades.View;
using Game.Scripts.Services.SceneLoader;
using Game.Scripts.Services.ScreenService;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Mechanics.Gameplay
{
    public class GameplayScreen: UIScreen
    {
        [SerializeField] private UIButton lobbyButton;
        private IScreenService _screenService;
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        protected override void StartHook() => lobbyButton.OnClick += ShowLobbyOnClick;
        private void ShowLobbyOnClick() => _sceneLoader.Load(Constants.LobbySceneName);
        protected override void OnDestroyHook() => lobbyButton.OnClick -= ShowLobbyOnClick;
    }
}