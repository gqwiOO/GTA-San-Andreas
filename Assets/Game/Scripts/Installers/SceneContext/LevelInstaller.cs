using Game.Scripts.Services.PlayerProvider;
using Zenject;

namespace Game.Scripts.Installers.SceneContext
{
    public class LevelInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerProvider>().AsSingle();
        }
    }
}