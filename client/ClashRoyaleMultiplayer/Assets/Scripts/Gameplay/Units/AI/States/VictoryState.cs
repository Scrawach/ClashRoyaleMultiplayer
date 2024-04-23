namespace Gameplay.Units.AI.States
{
    public class VictoryState : IState
    {
        private readonly Unit _owner;

        public VictoryState(Unit owner) => 
            _owner = owner;

        public void Enter() => 
            _owner.PlayVictory();

        public void Exit() { }
    }
}