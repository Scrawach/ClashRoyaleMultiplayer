using System;
using Gameplay.Towers;
using Gameplay.Units;
using Gameplay.Units.AI;
using Gameplay.Units.AI.States;

public class MoveToEnemyTowerState : IUpdatableState
{
    private readonly IStateMachine _stateMachine;
    private readonly TowerRegistry _towers;
    private readonly UnitMovement _movement;
    private readonly UnitAttack _attack;

    private Tower _nearestTower;

    public MoveToEnemyTowerState(IStateMachine stateMachine, TowerRegistry towers, UnitMovement movement, UnitAttack attack)
    {
        _stateMachine = stateMachine;
        _towers = towers;
        _movement = movement;
        _attack = attack;
    }

    public void Enter()
    {
        _towers.TryGetNearest(_movement.transform.position, out _nearestTower);
        _movement.MoveTo(_nearestTower.transform.position);
    }

    public void Update(float deltaTime)
    {
        if (_attack.InAttackRange(_nearestTower))
            _stateMachine.Enter<AttackState>();
    }

    public void Exit()
    {
        _movement.Stop();
    }
}