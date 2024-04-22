using System.Collections.Generic;
using Gameplay.Common;

namespace Gameplay.Towers
{
    public class TowerRegistry : MapObjectRegistry<Tower>
    {
        public TowerRegistry(IEnumerable<Tower> objects)
            : base(objects)
        { }
    }
}
