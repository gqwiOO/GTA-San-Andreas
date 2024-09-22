using System;
using Game.Scripts.Services.ScreenService;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Mechanics.Screen
{
    public class UIScreen: MonoBehaviour
    {
        private IScreenService _screenService;
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
        public event Action<UIScreen> OnDestroyed;

        [Inject]
        private void Construct(IScreenService screenService)
        {
            _screenService = screenService;
            _screenService.AddScreen(this);
        }

        private void Awake()
        {
            gameObject.SetActive(false);
            AwakeHook();
        }

        protected virtual void AwakeHook() { }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
            OnDestroyHook();
        }

        protected virtual void OnDestroyHook() { }
    }
}