using Game.Scripts.Enemy.Factory;
using Zenject;

namespace Game.Scripts.Installers.ProjectContext
{
    public class FactoryInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyFactory>().AsSingle();
        }
    }
}