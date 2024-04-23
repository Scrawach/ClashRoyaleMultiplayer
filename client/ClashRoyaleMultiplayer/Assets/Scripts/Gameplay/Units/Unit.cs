using System;
using Gameplay.Common;
using Gameplay.Towers;
using Gameplay.Units.Attacks;
using Gameplay.Units.Components;
using UnityEngine;

namespace Gameplay.Units
{
    public class Unit : MonoBehaviour, IDamageable
    {
        [SerializeField] private UnitMovement _movement;
        [SerializeField] private UnitAttack _attack;
        [SerializeField] private UnitAnimator _animator;
        [SerializeField] private Health _health;
        [SerializeField] private float _aggroRadius;

        private TowerRegistry _enemyTowers;
        private UnitRegistry _enemyUnits;

        private Tower _nearestTower;
        private Unit _nearestEnemy;
        private AttackData _currentTarget;

        public void Construct(TowerRegistry enemyTowers, UnitRegistry enemyUnits)
        {
            _enemyTowers = enemyTowers;
            _enemyUnits = enemyUnits;
        }
    
        public bool HasNearestTower() => 
            _enemyTowers.TryGetNearest(transform.position, out _nearestTower);

        public void MoveToNearestTower() => 
            _movement.MoveTo(_nearestTower.transform.position);

        public void StopMove() => 
            _movement.Stop();

        public bool HasChaseTarget()
        {
            var hasEnemy = _enemyUnits.TryGetNearest(transform.position, out _nearestEnemy, out var distance);
            return hasEnemy && distance < _aggroRadius;
        }

        public bool CanAttackTower() => 
            _nearestTower != null && _attack.InAttackRange(_nearestTower);

        public void ChaseToTarget() => 
            _movement.MoveTo(_nearestEnemy.transform.position);

        public bool HasAttackTarget()
        {
            if (_nearestTower != null && _attack.InAttackRange(_nearestTower))
            {
                _currentTarget = new AttackData(this, _nearestTower, _nearestTower.transform);
                return true;
            }

            if (_nearestEnemy != null && _attack.InAttackRange(_nearestEnemy))
            {
                _currentTarget = new AttackData(this, _nearestEnemy, _nearestEnemy.transform);
                return true;
            }

            return false;
        }

        public void AttackTarget(Action onAttackCompleted = null)
        {
            transform.LookAt(_currentTarget.TargetTransform);
            _attack.StartAttack(_currentTarget, onAttackCompleted);
        }

        public void StopAttack() => 
            _attack.StopAttack();

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _aggroRadius);
        }

        public void TakeDamage(int damage) => 
            _health.TakeDamage(damage);

        public void PlayVictory() => 
            _animator.PlayVictory();
    }
}