namespace Gameplay.Units.AI.States
{
    public interface IUpdatableState : IState
    {
        void Update(float deltaTime);
    }
}