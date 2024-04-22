using Gameplay.Towers;
using UnityEngine;

namespace Gameplay.Common
{
    public class DestroyTowerAfterDeath : MonoBehaviour
    {
        [SerializeField] private Tower _tower;
        [SerializeField] private Death _death;

        private TowerRegistry _towers;

        public void Construct(TowerRegistry towers) => 
            _towers = towers;

        private void OnEnable() => 
            _death.Happened += OnDeathHappened;

        private void OnDisable() => 
            _death.Happened -= OnDeathHappened;

        private void OnDeathHappened()
        {
            _towers.Remove(_tower);
            Destroy(_tower.gameObject);
        }
    }
}