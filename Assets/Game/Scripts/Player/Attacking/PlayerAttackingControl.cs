using Game.Scripts.Containers;
using Game.Scripts.Entity.Attacking;
using Game.Scripts.Mechanics;
using Game.Scripts.Mechanics.Combat.Data;
using Game.Scripts.Player.Config;
using Zenject;

namespace Game.Scripts.Player.Attacking
{
    public class PlayerAttackingControl: AttackControl
    {
        private HudContainer _hudContainer;
        private PlayerConfig _playerConfig;
        private EntityData _entityData;

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
            _hudContainer.RangeAttackButton.onClick.AddListener(RangeButton_onClick);   
        }

        private void Unsubscribe()
        {
            _hudContainer.MeleeAttackButton.onClick.RemoveListener(MeleeButton_onClick);   
            _hudContainer.RangeAttackButton.onClick.RemoveListener(RangeButton_onClick);   
        }

        private void MeleeButton_onClick() => AttackMelee(
            new AttackData(_entityData.meleeDamage,gameObject,_playerConfig.entityData.TeamTag));

        private void RangeButton_onClick() => RangeAttack(
            new AttackData(_entityData.rangeDamage,gameObject,_playerConfig.entityData.TeamTag));

        public void SetEntityData(EntityData entityData) => _entityData = entityData;
    }
}