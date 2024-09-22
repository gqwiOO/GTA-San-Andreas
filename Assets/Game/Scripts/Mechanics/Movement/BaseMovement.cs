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
        private float _lastAnimationValue;
        private bool _isActive = true;
        
        protected MovementConfig _movementConfig;

        [Inject]
        private void Construct(MovementConfig movementConfig)
        {
            _movementConfig = movementConfig;
        }
        
        public void SetState(bool state) => _isActive =state;
        protected void SetPosition(Vector2 targetPoint)
        {
            if (!_isActive)
                return;
            rb.position = targetPoint;
        }

        protected void SetVelocity(Vector2 velocity)
        {
            if (!_isActive)
            {
                rb.velocity = Vector2.zero;
                return;
            }
                
            rb.velocity = velocity;
        }

        protected void RotateTowardVector(Vector2 vector)
        {
            if (!_isActive)
                return;
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

        protected float GetDistanceToDestination(Vector3 destination)
        {
            Debug.Log($"Destination : {destination}, position : {transform.position}");
            return Vector3.Distance(transform.position, destination);
        }
    }
}