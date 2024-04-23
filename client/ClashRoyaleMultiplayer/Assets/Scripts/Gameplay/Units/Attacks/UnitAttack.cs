using System;
using Gameplay.Common;
using Gameplay.Towers;
using Gameplay.Units.Stats;
using UnityEngine;
using Range = Common.Range;

namespace Gameplay.Units.Attacks
{
    public abstract class UnitAttack : MonoBehaviour
    {
        protected float ModelSize;
        protected int Damage;
        protected float AttackCooldown;
        protected Range AttackRange;
        protected AttackAnimationInfo AttackAnimationInfo;
    
        public void Construct(float modelSize, int damage, float attackCooldown, Range attackRange, 
            AttackAnimationInfo attackAnimationInfo)
        {
            ModelSize = modelSize;
            Damage = damage;
            AttackCooldown = attackCooldown;
            AttackRange = attackRange;
            AttackAnimationInfo = attackAnimationInfo;
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