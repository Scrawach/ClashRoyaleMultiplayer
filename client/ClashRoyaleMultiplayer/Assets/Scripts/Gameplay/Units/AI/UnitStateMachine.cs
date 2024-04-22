using Gameplay.Units.AI.States;

namespace Gameplay.Units.AI
{
    public class UnitStateMachine : StateMachine
    {
        public UnitStateMachine(Unit owner)
        {
            AddState(new MoveToTowerState(this, owner));
            AddState(new ChaseState(this, owner));
            AddState(new AttackState(this, owner));
            AddState(new VictoryState());
        }
    }
}