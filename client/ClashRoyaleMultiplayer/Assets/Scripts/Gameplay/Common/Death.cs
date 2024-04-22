using System;
using UnityEngine;

namespace Gameplay.Common
{
    public class Death : MonoBehaviour
    {
        [SerializeField] private Health _health;

        public event Action Happened;
        
        private void OnEnable() => 
            _health.Changed += OnHealthChanged;

        private void OnDisable() => 
            _health.Changed -= OnHealthChanged;

        private void OnHealthChanged() => 
            Happened?.Invoke();
    }
}