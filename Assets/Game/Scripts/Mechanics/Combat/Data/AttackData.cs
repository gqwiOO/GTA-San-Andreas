using Game.Scripts.Player.Config;
using UnityEngine;

namespace Game.Scripts.Mechanics
{
    public class AttackData
    {
        public AttackData(float damage, GameObject attacker, TeamTag teamTag)
        {
            Damage = damage;
            Attacker = attacker;
            TeamTag = teamTag;
        }

        public float Damage { get; set; }
        public GameObject Attacker { get; set; }

        public TeamTag TeamTag { get; private set; }
    }
}