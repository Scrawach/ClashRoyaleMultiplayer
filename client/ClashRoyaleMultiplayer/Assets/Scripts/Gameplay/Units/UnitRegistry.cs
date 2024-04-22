using System.Collections.Generic;
using Gameplay.Common;

namespace Gameplay.Units
{
    public class UnitRegistry : MapObjectRegistry<Unit>
    {
        public UnitRegistry(IEnumerable<Unit> objects) 
            : base(objects) { }
    }
}