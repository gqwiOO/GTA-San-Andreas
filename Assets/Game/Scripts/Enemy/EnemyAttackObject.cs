﻿using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using Game.Scripts.Mechanics.Hp;
using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class EnemyAttackObject : AttackObject
    {
        [SerializeField] private HpView hpView;
        
        protected override void InitHook()
        {
            hpView.Init(HpSystem);
        }
    }
}