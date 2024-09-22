using Game.Scripts.Const;
using Game.Scripts.Enemy;
using Game.Scripts.Entity.Attacking.Data;
using Game.Scripts.Mechanics;
using Game.Scripts.Mechanics.Combat.Attack;
using Game.Scripts.Mechanics.Combat.Attack.Range;
using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entity.Attacking
{
    public class AttackControl: MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AttackCollider meleeCollider;
        [SerializeField] private AttackTargetGetter attackTargetGetter;

        [SerializeField] private Collider2D ignoredReceiveDamageCollider;

        [SerializeField] private Transform arrowSpawn;
        
        [SerializeField] private GameObject meleeWeapon;
        [SerializeField] private GameObject rangeWeapon;
        
        private ArrowPool _arrowPool;
        private AttackData _attackData;

        [Inject]
        private void Construct(ArrowPool arrowPool)
        {
            _arrowPool = arrowPool;
        }
        public void AttackMelee(AttackData attackData)
        {
            SetWeapon(true);
            
            animator.SetFloat(AnimatorId.AttackType, AttackTypes.MeleeAttack);
            animator.SetTrigger(AnimatorId.AttackTrigger);
            meleeCollider.SetAttackData(attackData);
        }

        public void RangeAttack(AttackData attackData)
        {
            SetWeapon(false);

            _attackData = attackData;
            animator.SetFloat(AnimatorId.AttackType, AttackTypes.RangeAttack);
            animator.SetTrigger(AnimatorId.AttackTrigger);
        }

        public void SetWeapon(bool IsMelee)
        {
            meleeWeapon.SetActive(IsMelee);
            rangeWeapon.SetActive(!IsMelee);
        }

        public void SpawnArrow()
        {
            var target = attackTargetGetter.GetClosest();
            
            var arrow = _arrowPool.Get(arrowSpawn.position, quaternion.identity);
            arrow.AddIgnoreCollider(ignoredReceiveDamageCollider);
            arrow.SetAttackData(_attackData);
            arrow.MoveInDirection((target - transform.position).normalized);
        }
    }
}