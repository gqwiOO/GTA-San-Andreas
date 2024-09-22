using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Mechanics.Movement.Config
{
    [CreateAssetMenu(menuName = "Movement/MovementConfig", fileName = "MovementConfig", order = 0)]
    public class MovementConfig: SerializedScriptableObject
    {
        public float walkMaxSpeed;
        public double minAnimationMoveValue;
        public float walkMaxAnimValue;
        
        [Header("Enemy")]
        public float enemyWalkMaxSpeed = 2000f;
        public float distanceToMeleeAttackByY = 0.2f;

        public float walkSpeedSelectRange = 50f;
    }
}