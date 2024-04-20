using UnityEngine;

public class AttackState : IUpdatableState
{
    public void Enter()
    {
        Debug.Log($"ATTACK STATE");
    }

    public void Exit()
    {
    }

    public void Update(float deltaTime)
    {
    }
}