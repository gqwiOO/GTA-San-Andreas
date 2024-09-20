using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Player.Movement
{
    [CreateAssetMenu(menuName = "Movement/MovementConfig", fileName = "MovementConfig", order = 0)]
    public class MovementConfig: SerializedScriptableObject
    {
        public float walkMaxSpeed;
        public double minAnimationMoveValue;
        public float walkToRunTranslation;
        public float maxRotationDegreesDelta;
        public float walkMaxAnimValue;
    }
}