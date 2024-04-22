using System;
using Gameplay.Towers;
using UnityEngine;

namespace Gameplay.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private UnitMovement _movement;
        [SerializeField] private UnitAttack _attack;

        private Tower _nearestTower;

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

        public void StopMove() => 
            _movement.Stop();

        public bool HasChaseTarget()
        {
            return false;
        }

        public bool CanAttackTower() => 
            _nearestTower != null && _attack.InAttackRange(_nearestTower);

        public void ChaseToTarget()
        {
        
        }

        public bool HasAttackTarget()
        {
            return false;
        }

        public void AttackTarget(Action onAttackCompleted = null)
        {
            throw new System.NotImplementedException();
        }
    }
}