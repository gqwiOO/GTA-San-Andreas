using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Containers
{
    public class HudContainer: MonoBehaviour
    {
        [field: SerializeField] public Button MeleeAttackButton { get; private set; }
        [field: SerializeField] public Button MagicAttackButton { get; private set; }
    }
}