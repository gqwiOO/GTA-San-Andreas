using Cinemachine;
using UnityEngine;

namespace Game.Scripts.Containers
{
    public class CamerasContainer: MonoBehaviour
    {
        [field: SerializeField] public CinemachineVirtualCamera DefaultCamera { get; private set; }
    }
}