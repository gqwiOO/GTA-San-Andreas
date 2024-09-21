using Game.Scripts.Containers;
using Game.Scripts.Enemy.Config;
using Game.Scripts.Factories.Config;
using Game.Scripts.Mechanics.Movement.Config;
using Game.Scripts.Player.Config;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Scripts.Installers.ProjectContext
{
    public class ConfigInstaller: MonoInstaller
    {
        [SerializeField] private MovementConfig movementConfig;
        [SerializeField] private ParticlesConfig particlesConfig;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private PrefabConfig prefabConfig;
        [FormerlySerializedAs("enemyConfig")] [SerializeField] private GlobalEnemyConfig globalEnemyConfig;

        public override void InstallBindings()
        {
            Container.Bind<MovementConfig>().FromInstance(movementConfig).AsSingle();
            Container.Bind<ParticlesConfig>().FromInstance(particlesConfig).AsSingle();
            Container.Bind<GlobalEnemyConfig>().FromInstance(globalEnemyConfig).AsSingle();
            Container.Bind<PlayerConfig>().FromInstance(playerConfig).AsSingle();
            Container.Bind<PrefabConfig>().FromInstance(prefabConfig).AsSingle();
        }
    }
}