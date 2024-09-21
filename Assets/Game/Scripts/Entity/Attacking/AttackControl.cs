using Game.Scripts.Const;
using Game.Scripts.Mechanics;
using Game.Scripts.Mechanics.Combat.Attack;
using Game.Scripts.Player.Movement;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Entity.Attacking
{
    public class AttackControl: MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AttackCollider meleeCollider;
        [SerializeField] private AttackCollider rangeCollider;
        public void AttackMelee(AttackData attackData)
        {
            animator.SetFloat(AnimatorId.AttackType, AttackTypes.MeleeAttack);
            animator.SetTrigger(AnimatorId.AttackTrigger);
            meleeCollider.SetAttackData(attackData);
        }

        public void MagicAttack(AttackData attackData)
        {
            animator.SetFloat(AnimatorId.AttackType, AttackTypes.MagicAttack);
            animator.SetTrigger(AnimatorId.AttackTrigger);
            rangeCollider.SetAttackData(attackData);
        }
    }
}