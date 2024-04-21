using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    private float _modelSize;
    private Range _attackRange;
    
    public void Construct(float modelSize, Range attackRange)
    {
        _modelSize = modelSize;
        _attackRange = attackRange;
    }

    public bool InAttackRange(Tower target)
    {
        var unitPosition = transform.position;
        var distance = target.GetDistance(unitPosition) - _modelSize;
        return distance > _attackRange.Min && distance < _attackRange.Max;
    }
}