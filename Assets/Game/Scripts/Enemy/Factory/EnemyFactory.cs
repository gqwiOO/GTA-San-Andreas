using Game.Scripts.Containers;
using Game.Scripts.Mechanics.Combat.Data;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemy.Factory
{
    public class EnemyFactory
    {
        private readonly PrefabConfig _prefabConfig;
        private DiContainer _diContainer;

        [Inject]
        public EnemyFactory(PrefabConfig prefabConfig, DiContainer diContainer)
        {
            _diContainer = diContainer;
            _prefabConfig = prefabConfig;
        }
        
        public EnemyAttackObject Create(AttackObjectData attackObjectData, Vector3 position, Transform parent = null)
        {
            var enemyAttackObject = Object.Instantiate(_prefabConfig.EnemyPrefab, position, quaternion.identity,parent);
            enemyAttackObject.Init(attackObjectData);
            _diContainer.InjectGameObjectForComponent<EnemyAttackObject>(enemyAttackObject.gameObject);
            return enemyAttackObject;
        }
    }
}