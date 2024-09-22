using System;
using System.Collections.Generic;
using Game.Scripts.Containers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Scripts.Mechanics.Combat.Attack.Range
{
    public class ArrowPool: IInitializable
    {
        private readonly PrefabConfig _prefabConfig;
        private Queue<Arrow> pool;
        private Arrow _arrowPrefab;

        private int _initialSize = 10;
        private ParentContainer _parentContainer;

        [Inject]
        public ArrowPool(PrefabConfig prefabConfig, ParentContainer parentContainer)
        {
            _parentContainer = parentContainer;
            _prefabConfig = prefabConfig;
        }

        public void Initialize()
        {
            _arrowPrefab = _prefabConfig.ArrowPrefab;
            pool = new Queue<Arrow>();

            for (int i = 0; i < _initialSize; i++)
            {
                CreateNewSprite();
            }
        }

        private Arrow CreateNewSprite()
        {
            Arrow arrowInstance = Object.Instantiate(_arrowPrefab,_parentContainer.ArrowParent);
            arrowInstance.gameObject.SetActive(false);
            pool.Enqueue(arrowInstance);
            return arrowInstance;
        }

        public Arrow Get(Vector3 position, Quaternion rotation)
        {
            if (pool.Count == 0)
            {
                CreateNewSprite();
            }

            var sprite = pool.Dequeue();
            sprite.transform.position = position;
            sprite.transform.rotation = rotation;
            sprite.gameObject.SetActive(true);
            return sprite;
        }

        public void ReturnSprite(Arrow sprite)
        {
            sprite.gameObject.SetActive(false);
            pool.Enqueue(sprite);
        }
    }
}