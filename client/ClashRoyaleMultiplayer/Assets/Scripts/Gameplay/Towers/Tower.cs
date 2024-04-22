using Gameplay.Common;
using UnityEngine;

namespace Gameplay.Towers
{
    public class Tower : MonoBehaviour, IDamageable
    {
        [SerializeField] private Health _health;
        [SerializeField] private float _modelSize;

        public float GetDistance(Vector3 point) => 
            Vector3.Distance(transform.position, point) - _modelSize;

        public void TakeDamage(int damage) => 
            _health.TakeDamage(damage);
    }
}