using System;
using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using UnityEngine;

namespace Game.Scripts.Services.PlayerProvider
{
    public interface IPlayerProvider
    {
        Vector3 Position { get; }
        bool Initialized { get; }
        
        event Action<AttackObject> OnDied;

        void Init(AttackObject attackObject);
    }
}