using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int Shoot = Animator.StringToHash("Shoot");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int Jump = Animator.StringToHash("Jump");
        
        public void Move() =>
            _animator.SetBool(IsRunning, true);

        public void StopMoving() =>
            _animator.SetBool(IsRunning, false);

        public void PlayHit() =>
            _animator.SetTrigger(Hit);

        public void PlayShoot() => 
            _animator.SetTrigger(Shoot);

        public void PlayJump() => 
            _animator.SetTrigger(Jump);
    }
}