using UnityEngine;

namespace Game.Scripts.Mechanics.Level
{
    [CreateAssetMenu(menuName = "LevelConfig", fileName = "LevelConfig", order = 0)]
    public class LevelConfig: ScriptableObject
    {
        public float enemySpawnRadius = 20;
    }
}