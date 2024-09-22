using System;
using Game.Scripts.Containers;
using Game.Scripts.Mechanics;
using Game.Scripts.Mechanics.Combat.Data;
using Game.Scripts.Mechanics.Combat.ReceiveDamage;
using Game.Scripts.Mechanics.Upgrades;
using Game.Scripts.Mechanics.Upgrades.Modifiers;
using Game.Scripts.Player.Attacking;
using Game.Scripts.Player.Config;
using Game.Scripts.Services.PlayerProvider;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player.Init
{
    public class PlayerInitializer: MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private UpgradeModifier upgradeModifier;
        
        private IPlayerProvider _playerProvider;
        private PlayerConfig _playerConfig;
        private PrefabConfig _prefabConfig;
        private ParentContainer _parentContainer;
        private DiContainer _diContainer;
        private CamerasContainer _camerasContainer;

        [Inject]
        private void Construct(DiContainer diContainer, IPlayerProvider playerProvider, PlayerConfig playerConfig,
            PrefabConfig prefabConfig, ParentContainer parentContainer, CamerasContainer camerasContainer)
        {
            _camerasContainer = camerasContainer;
            _diContainer = diContainer;
            _parentContainer = parentContainer;
            _prefabConfig = prefabConfig;
            _playerConfig = playerConfig;
            _playerProvider = playerProvider;
        }


        public void SpawnPlayer()
        {
            var instance = Instantiate(_prefabConfig.PlayerPrefab, playerSpawnPoint.position, quaternion.identity,
                _parentContainer.EntityContainer);
            
            _diContainer.InjectGameObject(instance.gameObject);

            _camerasContainer.DefaultCamera.Follow = instance.transform;
            
            _playerProvider.Init(instance);
            var modifiedEntityData = GetModifiedAttackObjectData(_playerConfig.entityData);
            instance.GetComponent<PlayerAttackingControl>().SetEntityData(modifiedEntityData);
            instance.Init(modifiedEntityData);
        }

        private EntityData GetModifiedAttackObjectData(EntityData entityData)
        {
            var playerConfigAttackObjectData = entityData;
            playerConfigAttackObjectData.MaxHp =
                upgradeModifier.Modify(UpgradeType.Health, playerConfigAttackObjectData.MaxHp);
            
            playerConfigAttackObjectData.meleeDamage =
                upgradeModifier.Modify(UpgradeType.MeleeAttack, playerConfigAttackObjectData.meleeDamage);
            
            playerConfigAttackObjectData.rangeDamage =
                upgradeModifier.Modify(UpgradeType.RangeAttack, playerConfigAttackObjectData.rangeDamage);
            return playerConfigAttackObjectData;
        }
    }
}