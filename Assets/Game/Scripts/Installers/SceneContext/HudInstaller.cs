using Game.Scripts.Mechanics.Hp;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers.SceneContext
{
    public class HudInstaller: MonoInstaller
    {
        [SerializeField] private HpView hpView;
        [SerializeField] private Joystick joystick;
        public override void InstallBindings()
        {
            Container.Bind<HpView>().FromInstance(hpView).AsSingle();
            Container.Bind<Joystick>().FromInstance(joystick).AsSingle();
        }
    }
}