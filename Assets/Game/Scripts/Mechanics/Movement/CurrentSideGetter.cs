using Game.Scripts.Mechanics.Movement.Data;
using UnityEngine;

namespace Game.Scripts.Mechanics.Movement
{
    public class CurrentSideGetter: MonoBehaviour
    {
        [SerializeField] private Transform scaleTarget;

        public Side GetSide() => scaleTarget.localScale.x > 0 ? Side.Left : Side.Right;
    }
}