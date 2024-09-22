using Game.Scripts.Services.ScreenService;
using Zenject;

namespace Game.Scripts.Installers.ProjectContext
{
    public class ScreenInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ScreenService>().AsSingle();
        }
    }
}