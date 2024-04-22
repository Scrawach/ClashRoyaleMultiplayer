namespace Gameplay.Units.AI.States
{
    public class MoveToTowerState : IUpdatableState
    {
        private readonly IStateMachine _stateMachine;
        private readonly Unit _unit;

        public MoveToTowerState(IStateMachine stateMachine, Unit unit)
        {
            _stateMachine = stateMachine;
            _unit = unit;
        }

        public void Enter()
        {
            if (_unit.HasNearestTower())
                _unit.MoveToNearestTower();
            else
                _stateMachine.Enter<VictoryState>();
        }
    
        public void Update(float deltaTime)
        {
            if (_unit.HasChaseTarget())
                _stateMachine.Enter<ChaseState>();
            else if (_unit.CanAttackTower())
                _stateMachine.Enter<AttackState>();
        }

        public void Exit()
        {
            _unit.StopMove();
        }
    }
}