using System;
using System.Collections.Generic;
using Game.Scripts.Player.Config;
using UnityEngine;

namespace Game.Scripts.Mechanics.Combat.Data
{
    [Serializable]
    public struct EntityData
    {
        [field: SerializeField] public float MaxHp { get; set; }
        
        [field: SerializeField] public float meleeDamage { get; set; }
        [field: SerializeField] public float rangeDamage { get; set; }
        
        public TeamTag TeamTag;
        public List<TeamTag> canReceiveDamageFrom;
        
        public EntityData(float maxHp, List<TeamTag> canReceiveDamageFrom, float rangeDamage, float meleeDamage, TeamTag teamTag)
        {
            MaxHp = maxHp;
            this.canReceiveDamageFrom = canReceiveDamageFrom;
            this.rangeDamage = rangeDamage;
            this.meleeDamage = meleeDamage;
            TeamTag = teamTag;
        }

    }
}