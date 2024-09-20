using Game.Scripts.Containers;
using Game.Scripts.Entity.Attacking;
using Game.Scripts.Mechanics.Particle.Pool;
using Zenject;

namespace Game.Scripts.Player.Attacking
{
    public class PlayerAttackingControl: AttackControl
    {
        private HudContainer _hudContainer;

        [Inject]
        private void Construct(HudContainer hudContainer)
        {
            _hudContainer = hudContainer;
        }

        private void Start()
        {
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _hudContainer.MeleeAttackButton.onClick.AddListener(AttackMelee);   
            _hudContainer.MagicAttackButton.onClick.AddListener(MagicAttack);   
        }
        
        private void Unsubscribe()
        {
            _hudContainer.MeleeAttackButton.onClick.RemoveListener(AttackMelee);   
            _hudContainer.MagicAttackButton.onClick.RemoveListener(MagicAttack);   
        }
    }
}