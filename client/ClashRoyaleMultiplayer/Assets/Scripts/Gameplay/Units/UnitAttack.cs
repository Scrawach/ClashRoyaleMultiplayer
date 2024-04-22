using System;
using System.Collections;
using Gameplay.Common;
using Gameplay.Towers;
using UnityEngine;
using Range = Common.Range;

namespace Gameplay.Units
{
    public class UnitAttack : MonoBehaviour
    {
        private float _modelSize;
        private int _damage;
        private Range _attackRange;
    
        public void Construct(float modelSize, int damage, Range attackRange)
        {
            _modelSize = modelSize;
            _damage = damage;
            _attackRange = attackRange;
        }

        public void Attack(IDamageable damageable, Action onCompleted = null) => 
            StartCoroutine(Attacking(damageable, onCompleted));
        
        public void StopAttack() { }

        public bool InAttackRange(Tower target) => 
            InAttackRange(target.GetDistance(transform.position));

        public bool InAttackRange(Unit target)
        {
            var distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            return InAttackRange(distanceToTarget);
        }

        private bool InAttackRange(float distanceToTarget)
        {
            var distance = distanceToTarget - _modelSize;
            return distance > _attackRange.Min && distance < _attackRange.Max;
        }
        
        private IEnumerator Attacking(IDamageable target, Action onCompleted)
        {
            yield return new WaitForSeconds(1);
            target.TakeDamage(_damage);
            onCompleted?.Invoke();
        }
    }
}