using Game.Scripts.Containers;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Scripts.Installers.SceneContext
{
    public class ContainerInstaller: MonoInstaller
    {
        [SerializeField] private HudContainer hudContainer;
        [SerializeField] private ParentContainer parentContainer;
        [SerializeField] private CamerasContainer camerasContainer;

        public override void InstallBindings()
        {
            Container.Bind<HudContainer>().FromInstance(hudContainer).AsSingle();
            Container.Bind<ParentContainer>().FromInstance(parentContainer).AsSingle();
            Container.Bind<CamerasContainer>().FromInstance(camerasContainer).AsSingle();
        }
    }
}