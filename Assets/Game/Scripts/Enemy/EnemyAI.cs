using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Enemy.Config;
using Game.Scripts.Entity.Attacking;
using Game.Scripts.Mechanics;
using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using Game.Scripts.Services.PlayerProvider;
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
        private IPlayerProvider _playerProvider;

        public AttackState SetAttackState { get; private set; }

        [Inject]
        private void Construct(GlobalEnemyConfig globalEnemyConfig, IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
            _globalEnemyConfig = globalEnemyConfig;
        }

        private void Start()
        {
            _disableAiCancellationTokenSource = new CancellationTokenSource();

            var tokenSource = CancellationTokenSource.CreateLinkedTokenSource(_disableAiCancellationTokenSource.Token,
                gameObject.GetCancellationTokenOnDestroy());
            
            attackObject.OnDied += DisableLogic_OnDied;

            SetAttackState = Random.Range(0, 1f) < _globalEnemyConfig.rangeEnemyChange 
                ? AttackState.Range 
                : AttackState.Melee;
            
            AiLogic(tokenSource.Token).Forget();
            
            attackControl.SetWeapon(SetAttackState == AttackState.Melee);
        }

        private void DisableLogic_OnDied(AttackObject _)
        {
            _disableAiCancellationTokenSource.Cancel();
            enemyMovement.ResetVelocity();
        }

        private async UniTask AiLogic(CancellationToken token)
        {
            await UniTask.WaitUntil(() => _playerProvider.Initialized, cancellationToken: token);
            while (true)
            {
                await enemyMovement.MoveTowardPlayer(SetAttackState, token);
                Attack();

                await UniTask.Delay(_globalEnemyConfig.attackDelayMilliseconds, cancellationToken: token);
            }
        }

        private void Attack()
        {
            if(SetAttackState == AttackState.Range)
                attackControl.RangeAttack(new AttackData(_globalEnemyConfig.entityData.rangeDamage,this.gameObject,_globalEnemyConfig.entityData.TeamTag));
            else
                attackControl.AttackMelee(new AttackData(_globalEnemyConfig.entityData.meleeDamage,this.gameObject,_globalEnemyConfig.entityData.TeamTag));
        }
    }

    public enum AttackState
    {
        Melee,
        Range
    }
}