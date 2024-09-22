using UnityEngine;

namespace Game.Scripts.Containers
{
    public class ParentContainer: MonoBehaviour
    {
        [field: SerializeField] public Transform ParticlesParent { get; private set; }
        [field: SerializeField] public Transform ArrowParent { get; private set; }
        [field: SerializeField] public Transform EntityContainer { get; private set; }
    }
}