using Game.Scripts.Factories;
using Game.Scripts.Mechanics.Combat.Attack;
using Game.Scripts.Mechanics.Particle;
using Game.Scripts.Mechanics.Particle.Pool;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entity.Attacking
{
    public class AttackAnimationListener: MonoBehaviour
    {
        private IParticlePool _particlePool;

        [SerializeField] private Transform rotationParent;
        [SerializeField] private AttackCollider meleeCollider;
        [SerializeField] private AttackCollider rangeCollider;

        [SerializeField] private Vector3 swordParticlesAdditivePos = new Vector3(0,2,0);
        [Inject]
        private void Construct(IParticlePool particlePool)
        {
            _particlePool = particlePool;
        }
        
        public void SwordAttackStarted()
        {
            _particlePool.GetParticle(ParticleId.SwordSmash, transform.position + swordParticlesAdditivePos, rotationParent.rotation);
            meleeCollider.Activate();
        }
        
        public void SwordAttackFinished()
        {
            meleeCollider.Deactivate();
        }
    }
}