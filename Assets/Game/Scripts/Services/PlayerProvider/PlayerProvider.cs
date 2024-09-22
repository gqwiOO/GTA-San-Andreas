using System;
using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Services.PlayerProvider
{
    public class PlayerProvider : IPlayerProvider, IDisposable
    {
        private GameObject _playerObject;
        private AttackObject _attackObject;
        public Vector3 Position => _playerObject.transform.position;
        
        public bool Initialized { get; private set; }

        public event Action<AttackObject> OnDied;
        public void Init(AttackObject attackObject)
        {
            _attackObject = attackObject;
            _playerObject = attackObject.gameObject;
            Initialized = true;
            attackObject.OnDied += Call_OnDied;
        }

        private void Call_OnDied(AttackObject _) => OnDied?.Invoke(_attackObject);

        public void Dispose() => _attackObject.OnDied -= Call_OnDied;
    }
}