using System;
using System.Collections.Generic;
using Gameplay.Units.AI.States;
using UnityEngine;

namespace Gameplay.Units.AI
{
    public class StateMachine : IStateMachine
    {
        private readonly IDictionary<Type, IState> _states;
        private IState _current;

        public StateMachine() => 
            _states = new Dictionary<Type, IState>();

        public void AddState<TState>(TState state) where TState : IState => 
            _states[typeof(TState)] = state;

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
            Debug.Log($"Enter to {typeof(TState)}");
            _current.Enter();
        }
    }
}