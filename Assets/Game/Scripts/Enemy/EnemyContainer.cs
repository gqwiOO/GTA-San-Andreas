using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Enemy.Config;
using Game.Scripts.Enemy.Factory;
using Game.Scripts.Mechanics;
using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using Game.Scripts.Mechanics.Level;
using Game.Scripts.Services.PlayerProvider;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemy
{
    public class EnemyContainer: MonoBehaviour
    {
        [SerializeField] private List<EnemyAttackObject> enemyAttackObjects = new ();
        [SerializeField] private int maxRespawnEnemyOnDead = 3;
        private EnemyFactory _enemyFactory;
        private GlobalEnemyConfig _enemyConfig;
        private LevelConfig _levelConfig;
        private IPlayerProvider _playerProvider;

        [Inject]
        private void Construct(EnemyFactory enemyFactory, GlobalEnemyConfig enemyConfig, LevelConfig levelConfig, IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
            _levelConfig = levelConfig;
            _enemyConfig = enemyConfig;
            _enemyFactory = enemyFactory;
        }

        public void Add(EnemyAttackObject enemyAttackObject)
        {
            enemyAttackObjects.Add(enemyAttackObject);
            enemyAttackObject.OnDied += Remove;
        }

        private void Remove(AttackObject enemy)
        {
            var enemyAttackObject = (EnemyAttackObject)enemy;
            enemyAttackObjects.Remove(enemyAttackObject);
            enemyAttackObject.OnDied -= Remove;
            Respawn();
        }

        private void Respawn()
        {
            for (int i = 0; i < Random.Range(1, maxRespawnEnemyOnDead + 1); i++)
            {
                var spawnPosition = _playerProvider.Position + Random.insideUnitSphere * _levelConfig.enemySpawnRadius;
                spawnPosition.z = 0;
                var instance = _enemyFactory.Create(_enemyConfig.AttackObjectData,spawnPosition,transform);
                Add(instance);
            }
        }

        public EnemyAttackObject GetClosest(Vector3 position) => enemyAttackObjects
            .OrderBy((obj => Vector3.Distance(obj.transform.position, position)))
            .First();
    }
}