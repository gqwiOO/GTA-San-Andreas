using System;
using Game.Scripts.Entity.Attacking;
using Game.Scripts.Mechanics.Movement;
using Game.Scripts.Services.PlayerProvider;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemy
{
    public class EnemyAI: MonoBehaviour
    {
        [SerializeField] private AttackControl attackControl;
        [SerializeField] private EnemyMovement enemyMovement;


        private void Start()
        {
            RunToPlayer();
        }

        private void RunToPlayer()
        {
            enemyMovement.MoveTowardPlayer(AttackState.Melee);   
        }
    }

    public enum AttackState
    {
        Melee,
        Range
    }
}