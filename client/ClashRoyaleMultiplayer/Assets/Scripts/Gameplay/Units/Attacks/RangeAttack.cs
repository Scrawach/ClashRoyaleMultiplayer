using System;
using System.Collections;
using Gameplay.Units.Components;
using UnityEngine;
using Object = System.Object;

namespace Gameplay.Units.Attacks
{
    public class RangeAttack : UnitAttack
    {
        [SerializeField] private UnitAnimator _animator;
        [SerializeField] private Projectile _projectile;
        [SerializeField] private Transform _shootPoint;
        
        public override void StartAttack(AttackData data, Action onCompleted = null) => 
            StartCoroutine(ShootProjectile(data, onCompleted));

        public override void StopAttack() { }

        private IEnumerator ShootProjectile(AttackData data, Action onCompleted = null)
        {
            _animator.PlayRangeAttack();
            yield return new WaitForSeconds(AttackAnimationInfo.PrepareTimeInSeconds);

            if (data.TargetTransform == null)
            {
                onCompleted?.Invoke();
                yield break;
            }
            
            var projectile = Instantiate(_projectile, _shootPoint.position, _shootPoint.rotation);
            projectile.Launch(data.TargetTransform, () => data.TargetHealth.TakeDamage(Damage));
            yield return new WaitForSeconds(AttackAnimationInfo.WaitingTimeInSeconds + AttackCooldown);
            onCompleted?.Invoke();
        }
    }
}