using Game.Scripts.Entity.Attacking;
using Game.Scripts.Services.PlayerProvider;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemy
{
    public class PlayerTargetGetter : AttackTargetGetter
    {
        private IPlayerProvider _playerProvider;

        [Inject]
        private void Construct(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }
        
        public override Vector3 GetClosest() => _playerProvider.Position;
    }
}