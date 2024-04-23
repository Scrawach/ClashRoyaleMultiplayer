using System;
using Gameplay.Common;
using Gameplay.Towers;
using UnityEngine;
using Range = Common.Range;

namespace Gameplay.Units.Attacks
{
    public abstract class UnitAttack : MonoBehaviour
    {
        protected float ModelSize;
        protected int Damage;
        protected Range AttackRange;
    
        public void Construct(float modelSize, int damage, Range attackRange)
        {
            ModelSize = modelSize;
            Damage = damage;
            AttackRange = attackRange;
        }
        
        public abstract void StartAttack(AttackData data, Action onCompleted = null);
        
        public abstract void StopAttack();

        public bool InAttackRange(Tower target) => 
            InAttackRange(target.GetDistance(transform.position));

        public bool InAttackRange(Unit target)
        {
            var distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            return InAttackRange(distanceToTarget);
        }

        private bool InAttackRange(float distanceToTarget)
        {
            var distance = distanceToTarget - ModelSize;
            return distance > AttackRange.Min && distance < AttackRange.Max;
        }
    }
}