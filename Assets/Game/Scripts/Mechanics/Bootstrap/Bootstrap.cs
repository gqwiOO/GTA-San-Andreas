using System;
using UnityEngine;

namespace Game.Scripts.Mechanics.Bootstrap
{
    public class Bootstrap: MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
    }
}