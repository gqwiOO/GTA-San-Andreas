using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Mechanics.Combat.ReceiveDamage
{
    public class ReceiveDamageCollider: MonoBehaviour
    {
        [SerializeField] private AttackObject attackObject;
        
        public void ReceiveAttackData(AttackData attackData)
        {
            if (attackData == null || !attackObject.AttackObjectData.canReceiveDamageFrom.Contains(attackData.TeamTag))
                return;
            attackObject.TriggerDamage(attackData);
        }
    }
}