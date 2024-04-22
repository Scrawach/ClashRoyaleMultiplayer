using Gameplay.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Image _bar;

        private void OnEnable() => 
            _health.Changed += OnHealthChanged;

        private void OnDisable() => 
            _health.Changed -= OnHealthChanged;

        private void OnHealthChanged() => 
            _bar.fillAmount = _health.Ratio;
    }
}