using System;
using Game.Scripts.Const;
using Game.Scripts.Mechanics;
using Game.Scripts.Mechanics.Combat.Attack;
using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using Game.Scripts.Mechanics.Movement;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player.Movement
{
    public class PlayerMovement: BaseMovement
    {
        [SerializeField] private AttackObject attackObject;
        
        private Joystick _joystickJoystick;

        [Inject]
        private void Construct(Joystick joystick)
        {
            _joystickJoystick = joystick;
        }

        private void Start() => attackObject.OnDied += DisableMovement;
        private void Update() => HorizontalMovement();
        private void OnDestroy() => attackObject.OnDied -= DisableMovement;
        private void DisableMovement(AttackObject _) => SetState(false);

        private void HorizontalMovement()
        {
#if !UNITY_EDITOR
            float x = _joystickJoystick.Horizontal;
            float y = _joystickJoystick.Vertical;
#else
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
#endif
            var direction = GetMoveDirection(x, y);
            float currentSpeed = _movementConfig.walkMaxSpeed;
            
            if(!(Mathf.Max(Mathf.Abs(x), Mathf.Abs(y)) > _movementConfig.minAnimationMoveValue))
            {
                SetAnimationValue(0, 0, 0.1f);
                SetVelocity(Vector2.Lerp(rb.velocity, Vector2.zero, 1f));
                return;
            }
            else{
                
                SetVelocity(new Vector2(x,y).normalized * currentSpeed);
                RotateTowardVector(GetMoveDirection(x,y));
            }
            SetAnimationValue(direction.magnitude,direction.magnitude);
        }
        private Vector2 GetMoveDirection(float x, float y) => new Vector2(x, y).normalized;
    }
}

    