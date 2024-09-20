using UnityEngine;

namespace Game.Scripts.Containers
{
    public class ParentContainer: MonoBehaviour
    {
        [field: SerializeField] public Transform ParticlesParent { get; private set; }
    }
}