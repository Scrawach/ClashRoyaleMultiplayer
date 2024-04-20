using UnityEngine;

public class MoveUnitToNearestEnemyTowerState : IUpdatableState
{
    private readonly IStateMachine _stateMachine;
    private readonly UnitMovement _movement;

    public MoveUnitToNearestEnemyTowerState(IStateMachine stateMachine, UnitMovement movement)
    {
        _stateMachine = stateMachine;
        _movement = movement;
    }

    public void Enter()
    {
        _movement.MoveTo(Vector3.zero);
    }

    public void Update(float deltaTime)
    {
        if (_movement.IsPositionReached)
            _stateMachine.Enter<AttackState>();
    }

    public void Exit()
    {
        
    }
}