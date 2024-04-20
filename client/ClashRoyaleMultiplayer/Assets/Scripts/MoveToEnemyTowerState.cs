using UnityEngine;

public class MoveToEnemyTowerState : IUpdatableState
{
    private readonly IStateMachine _stateMachine;
    private readonly TowerRegistry _towers;
    private readonly UnitMovement _movement;

    public MoveToEnemyTowerState(IStateMachine stateMachine, TowerRegistry towers, UnitMovement movement)
    {
        _stateMachine = stateMachine;
        _towers = towers;
        _movement = movement;
    }

    public void Enter()
    {
        var targetPosition = _towers.TryGetNearestTower(_movement.transform.position, out var tower)
            ? tower.transform.position
            : _movement.transform.position;
        
        _movement.MoveTo(targetPosition);
    }

    public void Update(float deltaTime)
    {
        if (_movement.IsPositionReached)
            _stateMachine.Enter<AttackState>();
    }

    public void Exit()
    {
        _movement.Stop();
    }
}