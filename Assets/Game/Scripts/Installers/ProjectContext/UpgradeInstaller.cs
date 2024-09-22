using Game.Scripts.Mechanics.Upgrades.Model;
using Zenject;

namespace Game.Scripts.Installers.ProjectContext
{
    public class UpgradeInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UpgradeModel>().AsSingle();
        }
    }
}