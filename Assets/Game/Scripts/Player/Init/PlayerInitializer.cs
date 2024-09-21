using System;
using Game.Scripts.Mechanics;
using Game.Scripts.Player.Config;
using Game.Scripts.Services.PlayerProvider;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player.Init
{
    public class PlayerInitializer: MonoBehaviour
    {
        [SerializeField] private AttackObject attackObject;
        
        private IPlayerProvider _playerProvider;
        private PlayerConfig _playerConfig;

        [Inject]
        private void Construct(IPlayerProvider playerProvider, PlayerConfig playerConfig)
        {
            _playerConfig = playerConfig;
            _playerProvider = playerProvider;
        }

        private void Awake()
        {
            _playerProvider.Init(gameObject);
            attackObject.Init(_playerConfig.AttackObjectData);
        }
    }
}