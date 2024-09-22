using Game.Scripts.Enemy;
using Game.Scripts.Mechanics.Combat.Attack.Range;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Containers
{
    [CreateAssetMenu(menuName = "PrefabConfig", fileName = "PrefabConfig", order = 0)]
    public class PrefabConfig: ScriptableObject
    {
        [field: SerializeField] public Arrow ArrowPrefab { get; private set; }
        [field: SerializeField] public EnemyAttackObject EnemyPrefab { get; private set; }
    }
}