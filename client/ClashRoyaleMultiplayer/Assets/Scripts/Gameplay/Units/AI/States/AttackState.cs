using UnityEngine;

namespace Gameplay.Units.AI.States
{
    public class AttackState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly Unit _unit;

        public AttackState(IStateMachine stateMachine, Unit unit)
        {
            _stateMachine = stateMachine;
            _unit = unit;
        }

        public void Enter()
        {
            if (_unit.HasAttackTarget())
                _unit.AttackTarget(OnAttackCompleted);
            else
                _stateMachine.Enter<MoveToTowerState>();
        }

        private void OnAttackCompleted() => 
            Enter();

        public void Exit() => 
            _unit.StopAttack();
    }
}