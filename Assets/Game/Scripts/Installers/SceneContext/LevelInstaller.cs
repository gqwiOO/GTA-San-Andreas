using Game.Scripts.Enemy;
using Game.Scripts.Services.PlayerProvider;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers.SceneContext
{
    public class LevelInstaller: MonoInstaller
    {
        [SerializeField] private EnemyContainer enemyContainer;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerProvider>().AsSingle();
            Container.Bind<EnemyContainer>().FromInstance(enemyContainer);
        }
    }
}