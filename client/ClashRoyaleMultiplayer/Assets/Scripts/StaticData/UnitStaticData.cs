using Gameplay.Units;
using Gameplay.Units.Stats;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "Unit Static Data", menuName = "Unit Data", order = 0)]
    public class UnitStaticData : ScriptableObject
    {
        [field: SerializeField] public UnitTypeId Type { get; private set; } 
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public UnitStats Stats { get; private set; }
    }
}