using System;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
    [SerializeField] private UnitMovement _movement;
    
    private IStateMachine _stateMachine;
    
    private void Awake()
    {
        _stateMachine = new StateMachine();
        _stateMachine
            .AddState(new MoveToEnemyTowerState(_stateMachine, _movement))
            .AddState(new AttackState());
        _stateMachine.Enter<MoveToEnemyTowerState>();
    }

    private void Update() => 
        _stateMachine.Update(Time.deltaTime);
}