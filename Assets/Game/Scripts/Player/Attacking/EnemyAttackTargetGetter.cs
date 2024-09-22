using Game.Scripts.Enemy;
using Game.Scripts.Entity.Attacking;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player.Attacking
{
    public class EnemyAttackTargetGetter : AttackTargetGetter
    {
        private EnemyContainer _enemyContainer;

        [Inject]
        private void Construct(EnemyContainer enemyContainer)
        {
            _enemyContainer = enemyContainer;
        }
        
        public override Vector3 GetClosest() => _enemyContainer.GetClosest(transform.position).transform.position;
    }
}