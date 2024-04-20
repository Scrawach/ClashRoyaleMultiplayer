using System;
using System.Collections.Generic;

public class StateMachine : IStateMachine
{
    private readonly Dictionary<Type, IState> _states;
    private IState _current;

    public StateMachine() => 
        _states = new Dictionary<Type, IState>();


    public IStateMachine AddState<TState>(TState state) where TState : IState
    {
        _states[typeof(TState)] = state;
        return this;
    }

    public void Enter<TState>() where TState : IState => 
        ChangeStateTo<TState>();

    public void Update(float deltaTime)
    {
        if (_current is IUpdatableState updatable)
            updatable.Update(deltaTime);
    }

    private void ChangeStateTo<TState>() where TState : IState
    {
        _current?.Exit();
        _current = _states[typeof(TState)];
        _current.Enter();
    }
}