using System;
using Range = Common.Range;

namespace Gameplay.Units
{
    [Serializable]
    public class UnitStats
    {
        public int Health;
        public float Speed;
        public float ModelSize;
        public Range AttackRange;
        public Range ChaseDistance;
    }
}