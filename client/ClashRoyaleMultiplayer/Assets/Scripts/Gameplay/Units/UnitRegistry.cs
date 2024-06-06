using System.Collections.Generic;
using System.Linq;
using Gameplay.Common;
using UnityEngine;

namespace Gameplay.Units
{
    public class UnitRegistry : MapObjectRegistry<Unit>
    {
        public UnitRegistry(IEnumerable<Unit> objects) 
            : base(objects) { }
        
        public bool TryGetNearest(Vector3 position, out Unit nearest, out float distance, bool withFlyingUnits = false) => 
            withFlyingUnits 
                ? base.TryGetNearest(position, out nearest, out distance) 
                : TryGetNearestWithoutFlying(position, out nearest, out distance);

        private bool TryGetNearestWithoutFlying(Vector3 position, out Unit nearest, out float distance)
        {
            distance = float.MaxValue;
            nearest = null;

            foreach (var unit in this.Where(x => x.IsFlying == false))
            {
                var mapDistance = Vector3.Distance(unit.transform.position, position);

                if (mapDistance < distance)
                {
                    distance = mapDistance;
                    nearest = unit;
                }
            }

            return nearest != null;
        }
    }
}