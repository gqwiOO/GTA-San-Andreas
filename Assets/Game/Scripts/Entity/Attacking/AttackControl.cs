using Game.Scripts.Player.Movement;
using UnityEngine;

namespace Game.Scripts.Entity.Attacking
{
    public class AttackControl: MonoBehaviour
    {
        [SerializeField] private Animator animator;

        protected void AttackMelee()
        {
            animator.SetFloat(AnimatorId.AttackType, AttackTypes.MeleeAttack);
            animator.SetTrigger(AnimatorId.AttackTrigger);
        }

        protected void MagicAttack()
        {
            animator.SetFloat(AnimatorId.AttackType, AttackTypes.MagicAttack);
            animator.SetTrigger(AnimatorId.AttackTrigger);
        }
    }
}