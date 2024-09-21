using UnityEngine;

namespace Game.Scripts.Mechanics.Combat.ReceiveDamage
{
    public class ReceiveDamageCollider: MonoBehaviour
    {
        [SerializeField] private AttackObject attackObject;

        public void ReceiveAttackData(AttackData attackData)
        {
            attackObject.TriggerDamage(attackData);
        }
    }
}