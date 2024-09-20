using Game.Scripts.Mechanics.Particle.Pool;
using Zenject;

namespace Game.Scripts.Installers
{
    public class ParticleInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ParticlePool>().AsSingle();
        }
    }
}