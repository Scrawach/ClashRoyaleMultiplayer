using System;
using Gameplay.Units.Stats;
using Range = Common.Range;

namespace Gameplay.Units
{
    [Serializable]
    public class UnitStats
    {
        public int Health;
        public int AttackDamage;
        public float AttackCooldownInSeconds;
        public float Speed;
        public float ModelSize;
        public Range AttackRange;
        public Range ChaseDistance;
        public AttackAnimationInfo AttackAnimationInfo;
    }
}