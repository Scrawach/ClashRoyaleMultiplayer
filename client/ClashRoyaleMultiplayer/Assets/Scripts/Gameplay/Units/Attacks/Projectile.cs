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
            var targetPosition = _target.position;
            targetPosition.y = transform.position.y;
            var distanceToTarget = Vector3.Distance(transform.position, targetPosition);

            var direction = _target.position - transform.position;
            var moveStep = _speed * Time.deltaTime;
            direction.y = 0;
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