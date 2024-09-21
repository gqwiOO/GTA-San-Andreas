using Game.Scripts.Const;
using Game.Scripts.Mechanics.Movement.Config;
using Game.Scripts.Mechanics.Movement.Data;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Mechanics.Movement
{
    public class BaseMovement: MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected Transform rotatedObject;
        [SerializeField] protected Animator animator;
        [SerializeField] private float rotateAccuracy = 0.1f;

        private Side _currentSide = Side.Left;
        protected float _lastAnimationValue;
        protected MovementConfig _movementConfig;

        [Inject]
        private void Construct(MovementConfig movementConfig)
        {
            _movementConfig = movementConfig;
        }

        protected void SetPosition(Vector2 targetPoint) => rb.position = targetPoint;
        protected void SetVelocity(Vector2 velocity) => rb.velocity = velocity;

        protected void RotateTowardVector(Vector2 vector)
        {
            if (vector.x > rotateAccuracy && _currentSide != Side.Right)
            {
                rotatedObject.transform.Rotate(new Vector3(0,1,0),180);
                _currentSide = Side.Right;
            }
            if (vector.x < -rotateAccuracy &&  _currentSide != Side.Left)
            {
                rotatedObject.transform.Rotate(new Vector3(0,1,0),180);
                _currentSide = Side.Left;
            }
        }
        
        protected void SetAnimationValue(float x, float y, float time = 0.3f)
        {
            var joystickAnimationValue = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
            var currentSpeed = animator.GetFloat(AnimatorId.Velocity);

            var animationValue = Mathf.Min(_movementConfig.walkMaxAnimValue, joystickAnimationValue);
            _lastAnimationValue = Mathf.Lerp(currentSpeed, animationValue, time);
            animator.SetFloat(AnimatorId.Velocity, _lastAnimationValue);
        }

        protected float GetDistanceToDestination(Vector3 destination) =>
            Vector3.Distance(transform.position, destination);
    }
}