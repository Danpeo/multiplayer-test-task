using System;
using Data;
using Infrastructure.Services.Network;
using Infrastructure.States;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(PlayerHealth), typeof(PlayerLocomotion), typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerShoot))]
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _health;
        [SerializeField] private PlayerLocomotion _locomotion;
        [SerializeField] private PlayerShoot _shoot;

        [FormerlySerializedAs("_gameOverScreen")] [SerializeField]
        private GameOverScreen _gameOverScreenPrefab;

        private bool _isDead;
        private GameOverState _gameOver;

        public event Action DeathOccured;

        private void Start() =>
            _health.HealthChanged += OnHealthChanged;


        private void OnDestroy()
        {
            _health.HealthChanged -= OnHealthChanged;
            DeathOccured?.Invoke();
        }

        private void OnHealthChanged()
        {
            if (!_isDead && _health.Current <= 0)
                Die();
        }

        private void Die()
        {
            _isDead = true;
            _locomotion.enabled = false;
            _shoot.enabled = false;
            _gameOver = new GameOverState(this, Instantiate(_gameOverScreenPrefab));

            Destroy(gameObject);
        }
    }
}