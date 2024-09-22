using Game.Scripts.Enemy.Factory;
using Game.Scripts.Mechanics.Combat.Attack.Range;
using Zenject;

namespace Game.Scripts.Installers.ProjectContext
{
    public class FactoryPoolInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ArrowPool>().AsSingle();
        }
    }
}