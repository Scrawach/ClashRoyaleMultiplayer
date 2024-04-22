using Gameplay.Units;
using UnityEngine;

namespace Gameplay.Common
{
    public class DestroyAfterDeath : MonoBehaviour
    {
        [SerializeField] private Unit _unit;
        [SerializeField] private Death _death;

        private UnitRegistry _units;

        public void Construct(UnitRegistry units) => 
            _units = units;

        private void OnEnable() => 
            _death.Happened += OnDeathHappened;

        private void OnDisable() => 
            _death.Happened -= OnDeathHappened;

        private void OnDeathHappened()
        {
            _units.Remove(_unit);
            Destroy(_unit.gameObject);
        }
    }
}