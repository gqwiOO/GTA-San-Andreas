using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Scripts.Mechanics.Combat.Attack.Range
{
    public class Arrow: AttackCollider
    {
        [SerializeField] private float speed;

        public void MoveInDirection(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            
            FlyAsync(direction).TimeoutWithoutException(new TimeSpan(0,0,10)).Forget();
        }

        private async UniTask FlyAsync(Vector3 direction)
        {
            while (true)
            {
                transform.position += direction * speed * Time.deltaTime;
                await UniTask.Yield();
            }
        }

        protected override void TriggerHook()
        {
            Destroy(gameObject);
        }
    }
}