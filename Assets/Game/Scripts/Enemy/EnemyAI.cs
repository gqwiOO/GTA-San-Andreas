using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Enemy.Config;
using Game.Scripts.Entity.Attacking;
using Game.Scripts.Mechanics;
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

        [Inject]
        private void Construct(GlobalEnemyConfig globalEnemyConfig)
        {
            _globalEnemyConfig = globalEnemyConfig;
        }

        private void Start()
        {
            _disableAiCancellationTokenSource = new CancellationTokenSource();
            AiLogic(_disableAiCancellationTokenSource.Token).Forget();
            attackObject.OnDied += DisableLogic_OnDied;
        }

        private void DisableLogic_OnDied(AttackObject _)
        {
            _disableAiCancellationTokenSource.Cancel();
        }

        private async UniTask AiLogic(CancellationToken token)
        {
            while (true)
            {
                await enemyMovement.MoveTowardPlayer(AttackState.Melee, token);
                if (enemyMovement.MoveResult == MoveResult.OnDestination)
                    Attack();

                await UniTask.Delay(1000, cancellationToken: token);
            }
        }

        private void Attack()
        {
            attackControl.AttackMelee(new AttackData(_globalEnemyConfig.meleeDamage,this.gameObject,_globalEnemyConfig.teamTag));
        }
    }

    public enum AttackState
    {
        Melee,
        Range
    }
}