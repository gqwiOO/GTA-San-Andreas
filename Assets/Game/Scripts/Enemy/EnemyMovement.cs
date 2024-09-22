using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Enemy.Config;
using Game.Scripts.Mechanics.Movement;
using Game.Scripts.Services.PlayerProvider;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Scripts.Enemy
{
    public class EnemyMovement : BaseMovement
    {
        private IPlayerProvider _playerProvider;
        private GlobalEnemyConfig _globalEnemyConfig;


        private float _moveSpeed;

        public MoveResult MoveResult { get; private set; }

        [Inject]
        private void Construct(IPlayerProvider playerProvider, GlobalEnemyConfig globalEnemyConfig)
        {
            _globalEnemyConfig = globalEnemyConfig;
            _playerProvider = playerProvider;
        }

        private void Start()
        {
            _moveSpeed = Random.Range(_movementConfig.enemyWalkMaxSpeed - _movementConfig.walkSpeedSelectRange,
                _movementConfig.enemyWalkMaxSpeed + _movementConfig.walkSpeedSelectRange);
            MoveResult = MoveResult.Cancelled;
        }

        public async UniTask MoveTowardPlayer(AttackState attackState, CancellationToken token)
        {
            var distanceToDestination = _globalEnemyConfig.attackDistance[attackState];
            await Move(distanceToDestination, token);
        }

        public void ResetVelocity() => rb.velocity = Vector2.zero;

        private async UniTask Move(float distanceToDestination, CancellationToken token)
        {
            while (GetDistanceToDestination(_playerProvider.Position) > distanceToDestination)
            {
                var direction = (_playerProvider.Position - transform.position).normalized;

                SetVelocity(direction * _moveSpeed);
                SetAnimationValue(direction.x, direction.y);
                RotateTowardVector(direction);
                await UniTask.NextFrame(cancellationToken: token);
            }


            SetVelocity(Vector2.zero);
            SetAnimationValue(0, 0, 1f);
            MoveResult = MoveResult.OnDestination;
        }
    }

    public enum MoveResult
    {
        OnDestination,
        Cancelled
    }
}