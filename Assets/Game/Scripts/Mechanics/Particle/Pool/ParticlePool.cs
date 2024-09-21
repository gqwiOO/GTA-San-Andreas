using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Containers;
using Game.Scripts.Factories;
using Game.Scripts.Factories.Config;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Scripts.Mechanics.Particle.Pool
{
    public class ParticlePool: IParticlePool, IInitializable, IDisposable
    {
        private Dictionary<ParticleId, Queue<ParticleSystem>> pools;
        
        private readonly Dictionary<ParticleId, ParticleSystem> particlePrefabs;

        private readonly int _initialSize;
        private readonly Transform _parent;

        [Inject]
        public ParticlePool(ParticlesConfig particlesConfig,ParentContainer parentContainer)
        {
            _parent = parentContainer.ParticlesParent;
            particlePrefabs = particlesConfig.particles;
            _initialSize = particlesConfig.initialSize;
        }
        
        public void Dispose()
        {
            pools.Clear();
        }
        
        public void Initialize()
        {
            pools = new Dictionary<ParticleId, Queue<ParticleSystem>>();

            foreach (var entry in particlePrefabs)
            {
                pools[entry.Key] = new Queue<ParticleSystem>();
                for (var i = 0; i < _initialSize; i++)
                {
                    CreateNewParticle(entry.Key);
                }
            }
        }

        private ParticleSystem CreateNewParticle(ParticleId id)
        {
            ParticleSystem particleInstance = Object.Instantiate(particlePrefabs[id],_parent);
            particleInstance.gameObject.SetActive(false);
            pools[id].Enqueue(particleInstance);
            return particleInstance;
        }

        public ParticleSystem GetParticle(ParticleId id, Vector3 position, Quaternion rotation, Transform tempParent = null)
        {
            if (pools[id].Count == 0)
            {
                CreateNewParticle(id);
            }

            var particle = pools[id].Dequeue();
            
            particle.transform.position = position;
            particle.transform.rotation = rotation;
            particle.gameObject.SetActive(true);
            if(tempParent != null)
                tempParent.SetParent(tempParent);
            
            particle.Play();
            
            WaitUntilEndAsync(id,particle,particle.GetCancellationTokenOnDestroy()).Forget();
            return particle;
        }

        private async UniTask WaitUntilEndAsync(ParticleId id, ParticleSystem particle,
            CancellationToken cancellationTokenOnDestroy)
        {
            await UniTask.WaitUntil(() => !particle.isPlaying, cancellationToken:cancellationTokenOnDestroy);
            ReturnParticle(id, particle);
        }


        private void ReturnParticle(ParticleId id, ParticleSystem particle)
        {
            particle.Stop();
            particle.gameObject.SetActive(false);
            particle.transform.SetParent(_parent);
            pools[id].Enqueue(particle);
        }
    }
}