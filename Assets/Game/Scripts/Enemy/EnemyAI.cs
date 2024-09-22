using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Enemy.Config;
using Game.Scripts.Entity.Attacking;
using Game.Scripts.Mechanics;
using Game.Scripts.Mechanics.Combat.Data;
using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using Game.Scripts.Services.PlayerProvider;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

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

        public AttackState AttackState { get; private set; }

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
            
            Subscriptions();

            SetAttackState();
            
            AiLogic(tokenSource.Token).Forget();
            
            attackControl.SetWeapon(AttackState == AttackState.Melee);
        }

        private void Subscriptions()
        {
            attackObject.OnDied += DisableLogic_OnDied;
            _playerProvider.OnDied += DisableLogic_OnDied;
        }

        private void OnDestroy()
        {
            Unsubscriptions();
        }

        private void Unsubscriptions()
        {
            attackObject.OnDied -= DisableLogic_OnDied;
            _playerProvider.OnDied -= DisableLogic_OnDied;
        }
        
        private void SetAttackState()
        {
            AttackState = Random.Range(0, 1f) < _globalEnemyConfig.rangeEnemyChange 
                ? AttackState.Range 
                : AttackState.Melee;
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
                await enemyMovement.MoveTowardPlayer(AttackState, token);
                Attack();

                await UniTask.Delay(_globalEnemyConfig.attackDelayMilliseconds, cancellationToken: token);
            }
        }

        private void Attack()
        {
            if(AttackState == AttackState.Range)
                attackControl.RangeAttack(new AttackData(_globalEnemyConfig.entityData.rangeDamage,this.gameObject,_globalEnemyConfig.entityData.TeamTag));
            else
                attackControl.AttackMelee(new AttackData(_globalEnemyConfig.entityData.meleeDamage,this.gameObject,_globalEnemyConfig.entityData.TeamTag));
        }
    }
}