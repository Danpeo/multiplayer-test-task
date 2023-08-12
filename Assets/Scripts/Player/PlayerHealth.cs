using System;
using Logic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private PlayerAnimator _animator;

        public event Action HealthChanged;

        [SerializeField] private float _current;
        
        public float Current
        {
            get => _current;
            set
            {
                if (_current != value)
                {
                    _current = value;
                    HealthChanged?.Invoke();
                }
            }
        }

        [SerializeField] private float _max;

        public float Max
        {
            get => _max;
            set => _max = value;
        }

        public void TakeDamage(float damage)
        {
            if (Current <= 0)
                return;

            Current -= damage;
            
            _animator.PlayHit();
        }

    }
}