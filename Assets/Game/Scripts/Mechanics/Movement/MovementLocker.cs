using UnityEngine;

namespace Game.Scripts.Mechanics.Movement
{
    public class MovementLocker: MonoBehaviour
    {
        public bool IsLocked { get; private set; }

        public void SetLockedStatus(bool status) => IsLocked = status;
    }
}