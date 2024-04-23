using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Units.Components
{
    public class UnitAnimator : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int RangeAttack = Animator.StringToHash("RangeAttack");
        private static readonly int Victory = Animator.StringToHash("Victory");

        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;

        private void Update()
        {
            if (_agent.velocity.magnitude > 0.1f)
                PlayMove();
            else
                StopMove();
        }

        public void PlayMove() => 
            _animator.SetBool(IsMoving, true);

        public void StopMove() => 
            _animator.SetBool(IsMoving, false);

        public void PlayAttack() => 
            _animator.SetTrigger(Attack);

        public void PlayRangeAttack() =>
            _animator.SetTrigger(RangeAttack);

        public void PlaySpawn()
        {
            
        }

        public void PlayVictory() => 
            _animator.SetTrigger(Victory);
    }
}