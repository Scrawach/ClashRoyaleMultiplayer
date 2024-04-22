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

    [SerializeField] private UnitStats _playerStats;
    [SerializeField] private UnitStats _enemyStats;
    
    private void Awake()
    {
        var enemyTowers = new TowerRegistry(_enemyTowers);
        var playerTowers = new TowerRegistry(_playerTowers);

        var enemyUnits = new UnitRegistry(_enemyUnits);
        var playerUnits = new UnitRegistry(_playerUnits);

        foreach (var enemyUnit in _enemyUnits)
            Initialize(enemyUnit, _enemyStats, playerTowers, playerUnits, enemyUnits);

        foreach (var playerUnit in _playerUnits) 
            Initialize(playerUnit, _playerStats, enemyTowers, enemyUnits, playerUnits);
    }

    private void Initialize(Unit target, UnitStats stats, TowerRegistry targetTowers, UnitRegistry targetUnits, UnitRegistry selfUnits)
    {
        target.Construct(targetTowers, targetUnits);
        target.GetComponent<UnitMovement>().SetSpeed(stats.Speed);
        target.GetComponent<UnitAttack>().Construct(stats.ModelSize, stats.AttackRange);
        target.GetComponent<Health>().Construct(stats.Health);
        target.GetComponent<DestroyAfterDeath>().Construct(selfUnits);

        target.GetComponent<NavMeshAgent>().stoppingDistance = stats.ModelSize + stats.AttackRange.Min;

        var stateMachine = new UnitStateMachine(target);
        target.GetComponent<UnitAI>().Construct(stateMachine);
    }
}