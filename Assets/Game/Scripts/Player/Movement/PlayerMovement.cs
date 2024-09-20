using System;
using System.Threading;
using Game.Scripts.Mechanics.Movement;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player.Movement
{
    public class PlayerMovement: BaseMovement
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Transform rotatingObject;
        [SerializeField] private MovementLocker _movementLocker;
        
        private MovementConfig _movementConfig;
        private Joystick _joystickJoystick;
        
        private float _lastAnimationValue;
        private bool _isStopped = true;

        [Inject]
        private void Construct(MovementConfig movementConfig, Joystick joystick)
        {
            _movementConfig = movementConfig;
            _joystickJoystick = joystick;
        }

        private void Update()
        {
            if (!_movementLocker.IsLocked)
            {
                HorizontalMovement();
            }
            else
            {
                SetAnimationValue(0,0);
                rb.velocity = Vector3.zero;
                _isStopped = true;
            }
        }

        private void ResetMovement()
        {
            _isStopped = true;
            SetVelocity(Vector2.zero);
            _movementLocker.SetMoving(false);
        }

        private void HorizontalMovement()
        {
#if !UNITY_EDITOR
            float x = _joystickJoystick.Horizontal;
            float y = _joystickJoystick.Vertical;
#else
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
#endif
            
            var temp = new Vector2(x, y);
            temp.Normalize();

            if (Mathf.Max(Math.Abs(x),Math.Abs(y)) < _movementConfig.minAnimationMoveValue)
            {
                ResetMovement();
            }
            else if (_isStopped)
            {
                _isStopped = false;
            }
            
            var movement = GetMoveDirection(temp.x, temp.y);

            float currentSpeed = _movementConfig.walkMaxSpeed * movement.magnitude * Time.fixedDeltaTime;
            
            if(!(Mathf.Max(Mathf.Abs(x), Mathf.Abs(y)) > _movementConfig.minAnimationMoveValue))
            {
                SetAnimationValue(0, 0, 0.1f);
                SetVelocity(Vector2.Lerp(rb.velocity, Vector2.zero, _movementConfig.walkToRunTranslation));
                return;
            }
            if (movement.magnitude > 0)
            {
                SetVelocity(new Vector2(x,y).normalized * currentSpeed);
                
                RotateTowardVector(GetMoveDirection(x,y));
                _movementLocker.SetMoving(true);
            }
            SetAnimationValue(temp.magnitude,temp.magnitude);
        }
        
        private void SetAnimationValue(float x, float y, float time = 0.3f)
        {
            var joystickAnimationValue = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
            var currentSpeed = animator.GetFloat(AnimatorId.Velocity);

            var animationValue = Mathf.Min(_movementConfig.walkMaxAnimValue, joystickAnimationValue);
            _lastAnimationValue = Mathf.Lerp(currentSpeed, animationValue, time);
            animator.SetFloat(AnimatorId.Velocity, _lastAnimationValue);
        }

        private Vector2 GetMoveDirection(float x, float y) => new (x, y);
    }
}

    