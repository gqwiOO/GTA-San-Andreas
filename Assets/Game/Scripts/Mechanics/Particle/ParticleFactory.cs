using Game.Scripts.Factories.Config;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Factories
{
    public class ParticleFactory
    {
        private ParticlesConfig _particlesConfig;

        [Inject]
        private void Construct(ParticlesConfig particlesConfig)
        {
            _particlesConfig = particlesConfig;
        }
        
        public void Create(ParticleId particleId, Vector2 position, Quaternion quaternion)
        {
            var instance =  Object.Instantiate(_particlesConfig.particles[particleId],position, quaternion);
            instance.Play();
        }
        
        public void Create(ParticleId particleId, Vector2 position)
        {
            var instance = Object.Instantiate(_particlesConfig.particles[particleId],position, Quaternion.identity);
            instance.Play();
        }
    }

    public enum ParticleId
    {
        SwordSmash
        
    }
}