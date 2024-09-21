using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Enemy.Config
{
    [CreateAssetMenu(menuName = "Enemy/EnemyConfig", fileName = "EnemyConfig", order = 0)]
    public class EnemyConfig: SerializedScriptableObject
    {
        public Dictionary<AttackState, int> attackDistance = new();
    }
}