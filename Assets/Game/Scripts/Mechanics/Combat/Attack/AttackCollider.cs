using System.Collections.Generic;
using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using UnityEngine;

namespace Game.Scripts.Mechanics.Combat.Attack
{
    [RequireComponent(typeof(Collider2D))]
    public class AttackCollider: MonoBehaviour
    {
        [SerializeField] private bool disableOnStart = true;
        [SerializeField] private List<Collider2D> ignoreColliders = new();
        private AttackData _attackData;

        private void Start()
        {
            if(disableOnStart)
                gameObject.SetActive(false);
            StartHook();
        }
        
        public void SetAttackData(AttackData attackData) => _attackData = attackData;

        public void Activate()
        {
            gameObject.SetActive(true);
            ActivateHook();
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            _attackData = null;
            DeactivateHook();
        }
        
        protected virtual void StartHook() { }
        protected virtual void ActivateHook() { }
        protected virtual void DeactivateHook() { }
        protected virtual void TriggerHook() { }

        public void AddIgnoreCollider(Collider2D col) => ignoreColliders.Add(col);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (ignoreColliders.Contains(other))
                return;
            
            var receiveDamageCollider = other.GetComponent<ReceiveDamageCollider>();
            if (_attackData == null || receiveDamageCollider.TeamTag == _attackData.TeamTag)
                return;
            
            receiveDamageCollider.ReceiveAttackData(_attackData);
            TriggerHook();
        }
    }
}