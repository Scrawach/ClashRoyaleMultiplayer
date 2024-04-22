using System.Collections.Generic;
using Gameplay.Common;
using Gameplay.Towers;
using Gameplay.Units;
using Gameplay.Units.AI;
using UnityEngine;
using UnityEngine.AI;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private List<Tower> _enemyTowers;
    [SerializeField] private List<Unit> _enemyUnits;

    [SerializeField] private List<Tower> _playerTowers;
    [SerializeField] private List<Unit> _playerUnits;

    [SerializeField] private UnitStats _stats;
    
    private void Awake()
    {
        var enemyTowers = new TowerRegistry(_enemyTowers);
        var playerTowers = new TowerRegistry(_playerTowers);

        var enemyUnits = new UnitRegistry(_enemyUnits);
        var playerUnits = new UnitRegistry(_playerUnits);

        foreach (var enemyUnit in _enemyUnits)
            Initialize(enemyUnit, playerTowers, playerUnits, enemyUnits);

        foreach (var playerUnit in _playerUnits) 
            Initialize(playerUnit, enemyTowers, enemyUnits, playerUnits);
    }

    private void Initialize(Unit target, TowerRegistry targetTowers, UnitRegistry targetUnits, UnitRegistry selfUnits)
    {
        target.Construct(targetTowers, targetUnits);
        target.GetComponent<UnitMovement>().SetSpeed(_stats.Speed);
        target.GetComponent<UnitAttack>().Construct(_stats.ModelSize, _stats.AttackRange);
        target.GetComponent<Health>().Construct(_stats.Health);
        target.GetComponent<DestroyAfterDeath>().Construct(selfUnits);

        target.GetComponent<NavMeshAgent>().stoppingDistance = _stats.ModelSize + _stats.AttackRange.Min;

        var stateMachine = new UnitStateMachine(target);
        target.GetComponent<UnitAI>().Construct(stateMachine);
    }
}