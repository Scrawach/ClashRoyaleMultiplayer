using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Common
{
    public class MapObjectRegistry<TMapObject> where TMapObject : Behaviour
    {
        private readonly List<TMapObject> _objects;

        public MapObjectRegistry(IEnumerable<TMapObject> objects) => 
            _objects = objects.ToList();

        public MapObjectRegistry<TMapObject> Add(TMapObject mapObject)
        {
            _objects.Add(mapObject);
            return this;
        }

        public bool Remove(TMapObject mapObject) => 
            _objects.Remove(mapObject);

        public bool TryGetNearest(Vector3 position, out TMapObject nearest) => 
            TryGetNearest(position, out nearest, out _);

        public bool TryGetNearest(Vector3 position, out TMapObject nearest, out float distance)
        {
            distance = float.MaxValue;
            nearest = null;

            foreach (var mapObject in _objects)
            {
                var mapDistance = Vector3.Distance(mapObject.transform.position, position);

                if (mapDistance < distance)
                {
                    distance = mapDistance;
                    nearest = mapObject;
                }
            }

            return nearest != null;
        }
    }
}