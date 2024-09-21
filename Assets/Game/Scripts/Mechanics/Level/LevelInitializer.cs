using System;
using Game.Scripts.Enemy.Config;
using Game.Scripts.Enemy.Factory;
using Game.Scripts.Services.PlayerProvider;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Scripts.Mechanics.Level
{
    public class LevelInitializer: MonoBehaviour
    {
        [SerializeField] private Transform enemiesParent;
        private EnemyFactory _enemyFactory;
        private GlobalEnemyConfig _globalEnemyConfig;
        private IPlayerProvider _playerProvider;

        [Inject]
        private void Construct(EnemyFactory enemyFactory, GlobalEnemyConfig globalEnemyConfig, IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
            _globalEnemyConfig = globalEnemyConfig;
            _enemyFactory = enemyFactory;
        }
        
        private void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                var spawnPosition = _playerProvider.Position + Random.insideUnitSphere * 20f;
                _enemyFactory.Create(_globalEnemyConfig.AttackObjectData, spawnPosition,enemiesParent);
            }
        }
    }
}