using Game.Scripts.Containers;
using Game.Scripts.Entity.Attacking;
using Game.Scripts.Mechanics;
using Game.Scripts.Player.Config;
using Zenject;

namespace Game.Scripts.Player.Attacking
{
    public class PlayerAttackingControl: AttackControl
    {
        private HudContainer _hudContainer;
        private PlayerConfig _playerConfig;

        [Inject]
        private void Construct(HudContainer hudContainer, PlayerConfig playerConfig)
        {
            _playerConfig = playerConfig;
            _hudContainer = hudContainer;
        }

        private void Start() => Subscribe();

        private void OnDestroy() => Unsubscribe();

        private void Subscribe()
        {
            _hudContainer.MeleeAttackButton.onClick.AddListener(MeleeButton_onClick);   
            _hudContainer.MagicAttackButton.onClick.AddListener(RangeButton_onClick);   
        }

        private void MeleeButton_onClick() => AttackMelee(new AttackData(_playerConfig.meleeDamage,gameObject,_playerConfig.teamTag));

        private void RangeButton_onClick() => AttackMelee(new AttackData(_playerConfig.rangeDamage,gameObject,_playerConfig.teamTag));

        private void Unsubscribe()
        {
            _hudContainer.MeleeAttackButton.onClick.RemoveListener(MeleeButton_onClick);   
            _hudContainer.MagicAttackButton.onClick.RemoveListener(RangeButton_onClick);   
        }
    }
}