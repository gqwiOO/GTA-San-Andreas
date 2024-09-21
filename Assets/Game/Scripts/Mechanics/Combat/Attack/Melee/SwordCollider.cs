using Game.Scripts.Mechanics.Movement;
using Game.Scripts.Mechanics.Movement.Data;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts.Mechanics.Combat.Attack.Melee
{
    public class SwordCollider: AttackCollider
    {
        [SerializeField] private Transform rotatingPoint;
        [SerializeField] private CurrentSideGetter currentSideGetter;


        private Vector3 _startLocalPosition;
        private float _lastRotatedAngle;

        protected override void StartHook()
        {
            _startLocalPosition = transform.localPosition;
        }

        protected override void ActivateHook()
        {
            var angle = currentSideGetter.GetSide() == Side.Left ? 60 : - 60;
            _lastRotatedAngle = angle;
            
            transform.RotateAround(rotatingPoint.position,new Vector3(0,0,1),angle);
        }

        protected override void DeactivateHook()
        {
            transform.rotation = quaternion.identity;
            transform.localPosition = _startLocalPosition;
        }
    }
}