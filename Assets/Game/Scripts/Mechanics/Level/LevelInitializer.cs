using System;
using Game.Scripts.Enemy;
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
        [SerializeField] private EnemyContainer enemiesParent;
        [SerializeField] private float maxEnemyRangeSpawn = 20f;
        [SerializeField] private int startEnemyCount = 3;
        
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
            for (int i = 0; i < startEnemyCount; i++)
            {
                var spawnPosition = _playerProvider.Position + Random.insideUnitSphere * maxEnemyRangeSpawn;
                spawnPosition.z = 0;
                var instance = _enemyFactory.Create(_globalEnemyConfig.AttackObjectData, spawnPosition,enemiesParent.transform);
                enemiesParent.Add(instance);
            }
        }
    }
}