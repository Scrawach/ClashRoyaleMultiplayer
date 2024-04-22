using Gameplay.Units.AI.States;

namespace Gameplay.Units.AI
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : IState;
        void Update(float deltaTime);
    }
}