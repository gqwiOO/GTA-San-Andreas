using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using UnityEngine;

namespace Game.Scripts.Mechanics.Combat.Attack
{
    [RequireComponent(typeof(Collider2D))]
    public class AttackCollider: MonoBehaviour
    {
        private AttackData _attackData;

        private void Start()
        {
            gameObject.SetActive(false);
            StartHook();
        }

        protected virtual void StartHook() { }

        public void SetAttackData(AttackData attackData) => _attackData = attackData;

        public void Activate()
        {
            gameObject.SetActive(true);
            ActivateHook();
        }

        protected virtual void ActivateHook() { }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            _attackData = null;
            DeactivateHook();
        }
        protected virtual void DeactivateHook() { }
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<ReceiveDamageCollider>().ReceiveAttackData(_attackData);
        }
    }
}