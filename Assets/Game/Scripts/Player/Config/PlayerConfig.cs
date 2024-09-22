using Game.Scripts.Mechanics.Combat.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Player.Config
{
    [CreateAssetMenu(menuName = "Player/PlayerConfig", fileName = "PlayerConfig", order = 0)]
    public class PlayerConfig: ScriptableObject
    {
        

        [FormerlySerializedAs("AttackObjectData")] public EntityData entityData;
        
    }

    public enum TeamTag
    {
        Player,
        Enemy
    }
}