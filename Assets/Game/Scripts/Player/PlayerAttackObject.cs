using Game.Scripts.Mechanics;
using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using Game.Scripts.Mechanics.Hp;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerAttackObject : AttackObject
    {
        private HpView _hpView;

        [Inject]
        private void Construct(HpView hpView)
        {
            _hpView = hpView;
        }
        
        protected override void InitHook()
        {
            _hpView.Init(HpSystem);
        }
    }
}