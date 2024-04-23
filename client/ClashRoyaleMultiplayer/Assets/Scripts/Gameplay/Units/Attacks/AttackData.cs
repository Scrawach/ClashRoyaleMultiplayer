using Gameplay.Common;
using UnityEngine;

namespace Gameplay.Units.Attacks
{
    public class AttackData
    {
        public Unit Attacker;
        public IDamageable TargetHealth;
        public Transform TargetTransform;

        public AttackData(Unit attacker, IDamageable targetHealth, Transform targetTransform)
        {
            Attacker = attacker;
            TargetHealth = targetHealth;
            TargetTransform = targetTransform;
        }
    }
}