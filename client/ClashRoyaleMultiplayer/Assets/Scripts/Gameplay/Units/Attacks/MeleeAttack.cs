﻿using System;
using System.Collections;
using Gameplay.Common;
using UnityEngine;

namespace Gameplay.Units.Attacks
{
    public class MeleeAttack : UnitAttack
    {
        [SerializeField] private UnitAnimator _animator;
        
        public override void StartAttack(AttackData data, Action onCompleted = null) => 
            StartCoroutine(Attacking(data.TargetHealth, onCompleted));
        
        public override void StopAttack() { }
        
        private IEnumerator Attacking(IDamageable target, Action onCompleted)
        {
            _animator.PlayAttack();
            yield return new WaitForSeconds(0.5f);
            target.TakeDamage(Damage);
            yield return new WaitForSeconds(0.5f);
            onCompleted?.Invoke();
        }
    }
}