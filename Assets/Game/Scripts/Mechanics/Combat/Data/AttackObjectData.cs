using System;
using System.Collections.Generic;
using Game.Scripts.Player.Config;
using UnityEngine;

namespace Game.Scripts.Mechanics.Combat.Data
{
    [Serializable]
    public class AttackObjectData
    {
        public AttackObjectData(int maxHp, List<TeamTag> canReceiveDamageFrom)
        {
            MaxHp = maxHp;
            this.canReceiveDamageFrom = canReceiveDamageFrom;
        }

        [field: SerializeField]public int MaxHp { get; private set; }


        public List<TeamTag> canReceiveDamageFrom;
    }
}