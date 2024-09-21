using UnityEngine;

namespace Game.Scripts.Mechanics
{
    public class AttackData
    {
        public AttackData(float damage, GameObject attacker)
        {
            Damage = damage;
            Attacker = attacker;
        }

        public float Damage { get; set; }
        public GameObject Attacker { get; set; }
    }
}