using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAI : MonoBehaviour
{
    [SerializeField] private UnitMovement _movement;
    [SerializeField] private UnitAttack _attack;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private UnitStats _stats;
    [SerializeField] private List<Tower> _enemyTowers;

    private IStateMachine _stateMachine;
    
    private void Awake()
    {
        var towers = new TowerRegistry(_enemyTowers);
        
        _movement.SetSpeed(_stats.Speed);
        _attack.Construct(_stats.ModelSize, _stats.AttackRange);
        _agent.stoppingDistance = _stats.ModelSize + _stats.AttackRange.Min;
        
        _stateMachine = new StateMachine();
        _stateMachine
            .AddState(new MoveToEnemyTowerState(_stateMachine, towers, _movement, _attack))
            .AddState(new AttackState());
        _stateMachine.Enter<MoveToEnemyTowerState>();
    }

    private void Update() => 
        _stateMachine.Update(Time.deltaTime);
}