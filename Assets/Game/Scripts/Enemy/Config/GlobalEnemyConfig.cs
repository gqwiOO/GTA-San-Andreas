using System.Collections.Generic;
using Game.Scripts.Mechanics.Combat.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Enemy.Config
{
    [CreateAssetMenu(menuName = "Enemy/EnemyConfig", fileName = "EnemyConfig", order = 0)]
    public class GlobalEnemyConfig: SerializedScriptableObject
    {
        public Dictionary<AttackState, float> attackDistance = new();
        public int attackDelayMilliseconds = 1000;

        public float rangeEnemyChange = 0.3f;

        [FormerlySerializedAs("AttackObjectData")] public EntityData entityData;
    }
}