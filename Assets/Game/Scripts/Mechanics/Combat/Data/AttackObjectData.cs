using System;

namespace Game.Scripts.Mechanics.Combat.Data
{
    [Serializable]
    public class AttackObjectData
    {
        public AttackObjectData(int maxHp)
        {
            MaxHp = maxHp;
        }

        public int MaxHp { get; set; }
        
    }
}