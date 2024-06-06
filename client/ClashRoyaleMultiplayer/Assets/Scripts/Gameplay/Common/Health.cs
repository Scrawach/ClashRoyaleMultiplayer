using System;
using UnityEngine;

namespace Gameplay.Common
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _current;
        [SerializeField] private int _total;

        public void Construct(int total)
        {
            _total = total;
            _current = total;
        }

        public float Ratio => 
            (float)_current / _total;
        
        public event Action Changed;
        
        public void TakeDamage(int damage)
        {
            _current = Mathf.Clamp(_current - damage, 0, _total);
            Changed?.Invoke();
        }
    }
}