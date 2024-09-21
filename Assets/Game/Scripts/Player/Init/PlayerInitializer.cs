using System;
using Game.Scripts.Services.PlayerProvider;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player.Init
{
    public class PlayerInitializer: MonoBehaviour
    {
        private IPlayerProvider _playerProvider;

        [Inject]
        private void Construct(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        private void Awake() => _playerProvider.Init(gameObject);
    }
}