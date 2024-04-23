using System;
using System.Collections;
using UnityEngine;

namespace Gameplay.Units.Attacks
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _triggerZone = 0.1f;

        private Transform _target;
        private Action _onCompleted;
        
        public void Launch(Transform target, Action onCompleted)
        {
            _target = target;
            _onCompleted = onCompleted;
        }

        private void Update()
        {
            var distanceToTarget = Vector3.Distance(transform.position, _target.position);

            var direction = _target.position - transform.position;
            var moveStep = _speed * Time.deltaTime;
            var movement = direction.normalized * moveStep;
            transform.Translate(movement, Space.World);

            if (distanceToTarget <= _triggerZone)
            {
                _onCompleted?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}