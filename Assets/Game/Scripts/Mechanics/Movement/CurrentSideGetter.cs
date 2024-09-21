using System;
using Game.Scripts.Mechanics.Movement.Data;
using UnityEngine;

namespace Game.Scripts.Mechanics.Movement
{
    public class CurrentSideGetter: MonoBehaviour
    {
        [SerializeField] private Transform scaleTarget;

        public Side GetSide() => 
            Math.Abs(scaleTarget.rotation.eulerAngles.y - 180) < 1f
                ? Side.Right 
                : Side.Left;
    }
}