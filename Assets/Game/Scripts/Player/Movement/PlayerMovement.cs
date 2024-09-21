using Game.Scripts.Const;
using Game.Scripts.Mechanics.Movement;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player.Movement
{
    public class PlayerMovement: BaseMovement
    {
        private Joystick _joystickJoystick;

        [Inject]
        private void Construct(Joystick joystick)
        {
            _joystickJoystick = joystick;
        }

        private void Update() => HorizontalMovement();

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
            float currentSpeed = _movementConfig.walkMaxSpeed * Time.deltaTime;
            
            if(!(Mathf.Max(Mathf.Abs(x), Mathf.Abs(y)) > _movementConfig.minAnimationMoveValue))
            {
                SetAnimationValue(0, 0, 0.1f);
                SetVelocity(Vector2.Lerp(rb.velocity, Vector2.zero, _movementConfig.walkToRunTranslation));
                return;
            }
            else{
                
                SetVelocity(new Vector2(x,y).normalized * currentSpeed);
                RotateTowardVector(GetMoveDirection(x,y));
            }
            SetAnimationValue(direction.magnitude,direction.magnitude);
        }
        
        private void SetAnimationValue(float x, float y, float time = 0.3f)
        {
            var joystickAnimationValue = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
            var currentSpeed = animator.GetFloat(AnimatorId.Velocity);

            var animationValue = Mathf.Min(_movementConfig.walkMaxAnimValue, joystickAnimationValue);
            _lastAnimationValue = Mathf.Lerp(currentSpeed, animationValue, time);
            animator.SetFloat(AnimatorId.Velocity, _lastAnimationValue);
        }

        private Vector2 GetMoveDirection(float x, float y) => new Vector2(x, y).normalized;
    }
}

    