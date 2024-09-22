using Game.Scripts.Mechanics.Combat.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Player.Config
{
    [CreateAssetMenu(menuName = "Player/PlayerConfig", fileName = "PlayerConfig", order = 0)]
    public class PlayerConfig: ScriptableObject
    {
        public float meleeDamage = 15;
        public float rangeDamage = 10;

        public AttackObjectData AttackObjectData;
        
    }

    public enum TeamTag
    {
        Player,
        Enemy
    }
}