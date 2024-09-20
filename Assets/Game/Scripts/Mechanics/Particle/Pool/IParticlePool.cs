using Game.Scripts.Factories;
using UnityEngine;

namespace Game.Scripts.Mechanics.Particle.Pool
{
    public interface IParticlePool
    {
        ParticleSystem GetParticle(ParticleId id, Vector3 position, Quaternion rotation);
    }
}