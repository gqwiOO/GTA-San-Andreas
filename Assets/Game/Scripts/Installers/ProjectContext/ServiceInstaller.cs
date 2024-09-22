using Game.Scripts.Mechanics.Menu;
using Game.Scripts.Services.SceneLoader;
using Zenject;

namespace Game.Scripts.Installers.ProjectContext
{
    public class ServiceInstaller: MonoInstaller    
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
        }
    }
}