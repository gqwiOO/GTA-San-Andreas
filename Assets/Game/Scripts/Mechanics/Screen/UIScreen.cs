using System;
using Game.Scripts.Services.ScreenService;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Mechanics.Screen
{
    public class UIScreen: MonoBehaviour
    {
        private IScreenService _screenService;
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);


        [Inject]
        private void Construct(IScreenService screenService)
        {
            _screenService = screenService;
            
            _screenService.AddScreen(this);
        }
    }
}