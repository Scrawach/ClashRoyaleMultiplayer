using UnityEngine;

namespace Gameplay.Units.AI.States
{
    public class VictoryState : IState
    {
        public void Enter()
        {
            Debug.Log($"VICTORY!");
        }

        public void Exit()
        {
        }
    }
}