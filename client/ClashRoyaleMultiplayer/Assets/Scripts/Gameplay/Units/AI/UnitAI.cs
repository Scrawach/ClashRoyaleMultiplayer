using Gameplay.Units.AI.States;
using UnityEngine;

namespace Gameplay.Units.AI
{
    public class UnitAI : MonoBehaviour
    {
        private IStateMachine _stateMachine;

        public void Construct(IStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        private void Start() =>
            _stateMachine.Enter<MoveToTowerState>();

        private void Update() => 
            _stateMachine.Update(Time.deltaTime);
    }
}