using Game.Scripts.Enemy.Config;
using Game.Scripts.Factories.Config;
using Game.Scripts.Mechanics.Movement.Config;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers.ProjectContext
{
    public class ConfigInstaller: MonoInstaller
    {
        [SerializeField] private MovementConfig movementConfig;
        [SerializeField] private ParticlesConfig particlesConfig;
        [SerializeField] private EnemyConfig enemyConfig;

        public override void InstallBindings()
        {
            Container.Bind<MovementConfig>().FromInstance(movementConfig).AsSingle();
            Container.Bind<ParticlesConfig>().FromInstance(particlesConfig).AsSingle();
            Container.Bind<EnemyConfig>().FromInstance(enemyConfig).AsSingle();
        }
    }
}