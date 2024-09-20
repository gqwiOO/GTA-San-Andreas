using Game.Scripts.Mechanics.Movement.Data;
using UnityEngine;

namespace Game.Scripts.Mechanics.Movement
{
    public class BaseMovement: MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected Transform rotatedObject;

        protected void SetPosition(Vector2 targetPoint) => rb.position = targetPoint;
        protected void SetVelocity(Vector2 velocity) => rb.velocity = velocity;

        [SerializeField] private float rotateAccuracy = 0.1f;
        
        private Side _currentSide = Side.Left;
        
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
    }
}