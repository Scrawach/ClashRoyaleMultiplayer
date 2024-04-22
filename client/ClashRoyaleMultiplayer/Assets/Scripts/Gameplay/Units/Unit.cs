using System;
using System.Collections;
using Gameplay.Towers;
using UnityEngine;

namespace Gameplay.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private UnitMovement _movement;
        [SerializeField] private UnitAttack _attack;
        [SerializeField] private float _aggroRadius;

        private Tower _nearestTower;
        private Unit _nearestEnemy;

        private TowerRegistry _enemyTowers;
        private UnitRegistry _enemyUnits;

        public void Construct(TowerRegistry enemyTowers, UnitRegistry enemyUnits)
        {
            _enemyTowers = enemyTowers;
            _enemyUnits = enemyUnits;
        }
    
        public bool HasNearestTower() => 
            _enemyTowers.TryGetNearest(transform.position, out _nearestTower);

        public void MoveToNearestTower() => 
            _movement.MoveTo(_nearestTower.transform.position);

        public void StopMove()
        {
            Debug.Log($"STOP MOVE");
            _movement.Stop();
        }

        public bool HasChaseTarget()
        {
            var hasEnemy = _enemyUnits.TryGetNearest(transform.position, out _nearestEnemy, out var distance);
            return hasEnemy && distance < _aggroRadius;
        }

        public bool CanAttackTower() => 
            _nearestTower != null && _attack.InAttackRange(_nearestTower);

        public void ChaseToTarget()
        {
            Debug.Log($"CHASE");
            _movement.MoveTo(_nearestEnemy.transform.position);
        }

        public bool HasAttackTarget()
        {
            if (_nearestEnemy == null)
                return false;

            var inAttackRange = _attack.InAttackRange(_nearestEnemy);
            return inAttackRange;
        }

        public void AttackTarget(Action onAttackCompleted = null)
        {
            Debug.Log($"ATTACK TARGET!");
            StartCoroutine(Attacking(onAttackCompleted));
        }

        public void StopAttack()
        {
            
        }

        private IEnumerator Attacking(Action onCompleted)
        {
            yield return new WaitForSeconds(1);
            onCompleted?.Invoke();
            Debug.Log($"Done Attack");
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _aggroRadius);
        }
    }
}