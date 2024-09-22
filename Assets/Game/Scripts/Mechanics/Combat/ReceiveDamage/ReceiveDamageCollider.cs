using System.Collections.Generic;
using Game.Scripts.Player.Config;
using UnityEngine;

namespace Game.Scripts.Mechanics.Combat.ReceiveDamage
{
    public class ReceiveDamageCollider: MonoBehaviour
    {
        [SerializeField] private AttackObject attackObject;

        public TeamTag TeamTag => attackObject.EntityData.TeamTag;
        
        public void ReceiveAttackData(AttackData attackData)
        {
            if (attackData == null || !attackObject.EntityData.canReceiveDamageFrom.Contains(attackData.TeamTag))
                return;
            attackObject.TriggerDamage(attackData);
        }
    }
}