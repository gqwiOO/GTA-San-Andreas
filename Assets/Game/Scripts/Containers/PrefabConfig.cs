using Game.Scripts.Enemy;
using UnityEngine;

namespace Game.Scripts.Containers
{
    [CreateAssetMenu(menuName = "PrefabConfig", fileName = "PrefabConfig", order = 0)]
    public class PrefabConfig: ScriptableObject
    {
        [field: SerializeField] public EnemyAttackObject enemyPrefab { get; private set; }
    }
}