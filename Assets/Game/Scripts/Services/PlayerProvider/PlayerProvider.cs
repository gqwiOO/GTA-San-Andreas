using UnityEngine;

namespace Game.Scripts.Services.PlayerProvider
{
    public class PlayerProvider : IPlayerProvider
    {
        private GameObject _playerObject;
        public Vector3 Position => _playerObject.transform.position;

        public void Init(GameObject gameObject)
        {
            _playerObject = gameObject;
        }
    }
}