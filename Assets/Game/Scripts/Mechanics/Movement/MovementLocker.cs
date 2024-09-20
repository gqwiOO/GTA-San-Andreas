using UnityEngine;

namespace Game.Scripts.Player.Movement
{
    public class MovementLocker: MonoBehaviour
    {
        public bool IsMoving { get; private set; }
        public bool IsLocked { get; private set; }

        public void SetMoving(bool status) => IsMoving = status;

        public void SetLockedStatus(bool status) => IsLocked = status;
    }
}