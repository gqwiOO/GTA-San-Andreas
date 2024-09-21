using System.Collections.Generic;
using Game.Scripts.Mechanics.Particle;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Factories.Config
{
    [CreateAssetMenu(menuName = "Particles", fileName = "ParticlesConfig", order = 0)]
    public class ParticlesConfig: SerializedScriptableObject
    {
        public Dictionary<ParticleId, ParticleSystem> particles;
        public int initialSize = 4;

    }
}