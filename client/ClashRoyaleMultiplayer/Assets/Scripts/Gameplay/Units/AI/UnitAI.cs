using System.Collections.Generic;
using Gameplay.Towers;
using Gameplay.Units.AI.States;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Units.AI
{
    public class UnitAI : MonoBehaviour
    {
        [SerializeField] private UnitMovement _movement;
        [SerializeField] private UnitAttack _attack;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Unit _unit;
        [SerializeField] private UnitStats _stats;
        [SerializeField] private List<Tower> _enemyTowers;

        private IStateMachine _stateMachine;
    
        private void Awake()
        {
            var towers = new TowerRegistry(_enemyTowers);
            var units = new UnitRegistry(new Unit[] { null });
        
            _unit.Construct(towers, units);
        
            _movement.SetSpeed(_stats.Speed);
            _attack.Construct(_stats.ModelSize, _stats.AttackRange);
            _agent.stoppingDistance = _stats.ModelSize + _stats.AttackRange.Min;

            _stateMachine = new UnitStateMachine(_unit);
            _stateMachine.Enter<MoveToTowerState>();
        }

        private void Update() => 
            _stateMachine.Update(Time.deltaTime);
    }
}