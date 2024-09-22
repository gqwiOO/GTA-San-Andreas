using Game.Scripts.Enemy;
using Game.Scripts.Mechanics.Combat.Attack.Range;
using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using UnityEngine;

namespace Game.Scripts.Containers
{
    [CreateAssetMenu(menuName = "PrefabConfig", fileName = "PrefabConfig", order = 0)]
    public class PrefabConfig: ScriptableObject
    {
        [field: SerializeField] public Arrow ArrowPrefab { get; private set; }
        [field: SerializeField] public EnemyAttackObject EnemyPrefab { get; private set; }
        [field: SerializeField] public AttackObject PlayerPrefab { get; private set; }
    }
}