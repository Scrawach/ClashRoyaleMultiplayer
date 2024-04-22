namespace Gameplay.Units.AI.States
{
    public class ChaseState : IUpdatableState
    {
        private readonly IStateMachine _stateMachine;
        private readonly Unit _unit;

        public ChaseState(IStateMachine stateMachine, Unit unit)
        {
            _stateMachine = stateMachine;
            _unit = unit;
        }

        public void Enter()
        {
            if (_unit.HasChaseTarget())
                _unit.ChaseToTarget();
        }

        public void Exit() { }

        public void Update(float deltaTime)
        {
            if (!_unit.HasChaseTarget())
                _stateMachine.Enter<MoveToTowerState>();
        }
    }
}