using Game.Scripts.Factories.Config;
using Game.Scripts.Player.Movement;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class ConfigInstaller: MonoInstaller
    {
        [SerializeField] private MovementConfig movementConfig;
        [SerializeField] private ParticlesConfig particlesConfig;
        public override void InstallBindings()
        {
            Container.Bind<MovementConfig>().FromInstance(movementConfig).AsSingle();
            Container.Bind<ParticlesConfig>().FromInstance(particlesConfig).AsSingle();
        }
    }
}