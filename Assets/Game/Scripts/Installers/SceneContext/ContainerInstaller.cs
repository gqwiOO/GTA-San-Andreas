using Game.Scripts.Containers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers.SceneContext
{
    public class ContainerInstaller: MonoInstaller
    {
        [SerializeField] private HudContainer hudContainer;
        [SerializeField] private ParentContainer parentContainer;

        public override void InstallBindings()
        {
            Container.Bind<HudContainer>().FromInstance(hudContainer).AsSingle();
            Container.Bind<ParentContainer>().FromInstance(parentContainer).AsSingle();

        }
    }
}