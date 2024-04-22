using UnityEngine;

namespace Gameplay.Units
{
    public class UnitAggro : MonoBehaviour
    {
        [field: SerializeField] public float AggroRadius { get; set; }
        
        private UnitRegistry _enemies;

        public void Construct(UnitRegistry enemies) => 
            _enemies = enemies;

        public bool HasEnemyInAggroRadius()
        {
            var hasEnemy = _enemies.TryGetNearest(transform.position, out var target, out var distance);
            return hasEnemy;
        }
    }
}