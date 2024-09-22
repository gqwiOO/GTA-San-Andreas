using Game.Scripts.Mechanics.Combat.Attack;
using UnityEngine;

namespace Game.Scripts.Entity.Attacking
{
    public class AttackAnimationListener: MonoBehaviour
    {
        [SerializeField] private AttackCollider meleeCollider;
        [SerializeField] private AttackControl attackControl;

        public void SwordAttackStarted()
        {
            meleeCollider.Activate();
        }
        
        public void SwordAttackFinished()
        {
            meleeCollider.Deactivate();
        }

        public void SpawnArrow_OnTriggered()
        {
            attackControl.SpawnArrow();
        }
    }
}