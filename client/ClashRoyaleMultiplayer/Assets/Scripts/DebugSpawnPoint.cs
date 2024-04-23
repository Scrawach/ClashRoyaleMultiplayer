using StaticData;
using UnityEngine;

public class DebugSpawnPoint : MonoBehaviour
{
    public UnitTypeId TypeId;
    public TeamId TeamId;

    private void OnDrawGizmos()
    {
        Gizmos.color = TeamId == TeamId.Enemy ? Color.red : Color.blue;
        Gizmos.DrawSphere(transform.position, 1f);
    }
}