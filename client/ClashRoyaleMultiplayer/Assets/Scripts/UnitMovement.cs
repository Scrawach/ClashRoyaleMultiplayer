using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    
    public bool IsPositionReached { get; private set; }

    public void MoveTo(Vector3 position) => 
        _agent.SetDestination(position);

    private void Update()
    {
        var distanceToPosition = Vector3.Distance(transform.position, _agent.destination);
        IsPositionReached = distanceToPosition < _agent.stoppingDistance;
    }

    public void Stop() => 
        _agent.isStopped = true;
}