using System;
using Game.Scripts.Enemy;
using Game.Scripts.Enemy.Config;
using Game.Scripts.Enemy.Factory;
using Game.Scripts.Mechanics.Gameplay;
using Game.Scripts.Player.Init;
using Game.Scripts.Services.PlayerProvider;
using Game.Scripts.Services.ScreenService;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Scripts.Mechanics.Level
{
    public class GameInitializer: MonoBehaviour
    {
        [SerializeField] private EnemyContainer enemiesParent;
        [SerializeField] private PlayerInitializer playerInitializer;
        [SerializeField] private float maxEnemyRangeSpawn = 20f;
        [SerializeField] private int startEnemyCount = 3;
        
        private EnemyFactory _enemyFactory;
        private GlobalEnemyConfig _globalEnemyConfig;
        private IPlayerProvider _playerProvider;
        private IScreenService _screenService;

        [Inject]
        private void Construct(EnemyFactory enemyFactory, GlobalEnemyConfig globalEnemyConfig, IPlayerProvider playerProvider,
            IScreenService screenService)
        {
            _screenService = screenService;
            _playerProvider = playerProvider;
            _globalEnemyConfig = globalEnemyConfig;
            _enemyFactory = enemyFactory;
        }
        
        private void Start()
        {
            playerInitializer.SpawnPlayer();
            SpawnEnemies();
            _screenService.Show<GameplayScreen>();
        }

        private void SpawnEnemies()
        {
            for (int i = 0; i < startEnemyCount; i++)
            {
                var spawnPosition = _playerProvider.Position + Random.insideUnitSphere * maxEnemyRangeSpawn;
                spawnPosition.z = 0;
                var instance = _enemyFactory.Create(_globalEnemyConfig.entityData, spawnPosition,enemiesParent.transform);
                enemiesParent.Add(instance);
            }
        }
    }
}