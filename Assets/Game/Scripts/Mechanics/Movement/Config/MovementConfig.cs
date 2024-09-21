using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Mechanics.Movement.Config
{
    [CreateAssetMenu(menuName = "Movement/MovementConfig", fileName = "MovementConfig", order = 0)]
    public class MovementConfig: SerializedScriptableObject
    {
        public float walkMaxSpeed;
        public double minAnimationMoveValue;
        public float walkToRunTranslation;
        public float maxRotationDegreesDelta;
        public float walkMaxAnimValue;
        
        [Header("Enemy")]
        public float enemyWalkMaxSpeed = 2000f;
    }
}