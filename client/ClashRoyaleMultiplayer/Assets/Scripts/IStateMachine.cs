public interface IStateMachine
{
    IStateMachine AddState<TState>(TState state) where TState : IState;
    void Enter<TState>() where TState : IState;
    void Update(float deltaTime);
}