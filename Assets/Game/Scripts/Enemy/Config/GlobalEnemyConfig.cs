using System.Collections.Generic;
using Game.Scripts.Mechanics.Combat.Data;
using Game.Scripts.Player.Config;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Enemy.Config
{
    [CreateAssetMenu(menuName = "Enemy/EnemyConfig", fileName = "EnemyConfig", order = 0)]
    public class GlobalEnemyConfig: SerializedScriptableObject
    {
        public Dictionary<AttackState, int> attackDistance = new();
        public int attackDelayMilliseconds = 1000;

        public float meleeDamage = 10;
        public float rangeDamage = 8;

        public AttackObjectData AttackObjectData;

        public TeamTag teamTag;
    }
}