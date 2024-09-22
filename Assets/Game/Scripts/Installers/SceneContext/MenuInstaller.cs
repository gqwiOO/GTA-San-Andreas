using Game.Scripts.Mechanics.Menu;
using Zenject;

namespace Game.Scripts.Installers.SceneContext
{
    public class MenuInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MenuManager>().AsSingle();
        }
    }
}