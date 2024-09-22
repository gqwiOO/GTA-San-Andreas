using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Enemy.Config;
using Game.Scripts.Entity.Attacking;
using Game.Scripts.Mechanics;
using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemy
{
    public class EnemyAI: MonoBehaviour
    {
        [SerializeField] private AttackControl attackControl;
        [SerializeField] private EnemyMovement enemyMovement;
        [SerializeField] private AttackObject attackObject;
        
        private GlobalEnemyConfig _globalEnemyConfig;

        private CancellationTokenSource _disableAiCancellationTokenSource;

        public AttackState AttackState { get; private set; }

        [Inject]
        private void Construct(GlobalEnemyConfig globalEnemyConfig)
        {
            _globalEnemyConfig = globalEnemyConfig;
        }

        private void Start()
        {
            _disableAiCancellationTokenSource = new CancellationTokenSource();
            attackObject.OnDied += DisableLogic_OnDied;

            AttackState = Random.Range(0, 1f) < _globalEnemyConfig.rangeEnemyChange ? AttackState.Range : AttackState.Melee;
            // AttackState = AttackState.Melee;
            AttackState = AttackState.Range;
            
            AiLogic(_disableAiCancellationTokenSource.Token).Forget();
            
            attackControl.SetWeapon(AttackState == AttackState.Melee);
            
        }

        private void DisableLogic_OnDied(AttackObject _)
        {
            _disableAiCancellationTokenSource.Cancel();
            enemyMovement.ResetVelocity();
        }

        private async UniTask AiLogic(CancellationToken token)
        {
            while (true)
            {
                await enemyMovement.MoveTowardPlayer(AttackState, token);
                if (enemyMovement.MoveResult == MoveResult.OnDestination)
                {
                    Attack();
                    Debug.Log("OnDestination");
                }

                await UniTask.Yield( cancellationToken: token);
            }
        }

        private void Attack()
        {
            if(AttackState == AttackState.Range)
                attackControl.RangeAttack(new AttackData(_globalEnemyConfig.rangeDamage,this.gameObject,_globalEnemyConfig.AttackObjectData.TeamTag));
            else
                attackControl.AttackMelee(new AttackData(_globalEnemyConfig.meleeDamage,this.gameObject,_globalEnemyConfig.AttackObjectData.TeamTag));
        }
    }

    public enum AttackState
    {
        Melee,
        Range
    }
}