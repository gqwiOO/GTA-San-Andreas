using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.Enemy.Config;
using Game.Scripts.Mechanics.Movement;
using Game.Scripts.Services.PlayerProvider;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemy
{
    public class EnemyMovement: BaseMovement
    {
        private IPlayerProvider _playerProvider;
        private EnemyConfig _enemyConfig;

        [Inject]
        private void Construct(IPlayerProvider playerProvider, EnemyConfig enemyConfig)
        {
            _enemyConfig = enemyConfig;
            _playerProvider = playerProvider;
        }
        public void MoveTowardPlayer(AttackState attackState)
        {
            var distanceToDestination = _enemyConfig.attackDistance[attackState];
            Move(distanceToDestination).Forget();
        }

        private async UniTask Move(int distanceToDestination)
        {
            while (GetDistanceToDestination(_playerProvider.Position) > distanceToDestination)
            {
                var direction = (_playerProvider.Position - transform.position).normalized;
                SetVelocity(direction * (_movementConfig.enemyWalkMaxSpeed * Time.deltaTime));
                SetAnimationValue(direction.x, direction.y);
                RotateTowardVector(direction);
                await UniTask.Delay(400);
            }

            SetVelocity(Vector2.zero);
            SetAnimationValue(0,0,1f);
        }

    }
}