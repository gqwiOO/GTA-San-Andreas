using UnityEngine;

namespace Game.Scripts.Services.PlayerProvider
{
    public interface IPlayerProvider
    {
        Vector3 Position { get; }
        void Init(GameObject gameObject);
    }
}