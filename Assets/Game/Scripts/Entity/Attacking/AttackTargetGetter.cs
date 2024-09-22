using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using UnityEngine;

namespace Game.Scripts.Entity.Attacking
{
    public abstract class AttackTargetGetter: MonoBehaviour
    {
        public abstract Vector3 GetClosest();
    }
}