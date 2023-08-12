using Logic;
using Player;
using UnityEngine;

namespace UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private CoinDisplayCount _coinDisplay;
        [SerializeField] private NameDisplay _nameDisplay;
        private IHealth _health;
        private ICoins _coins;
        private PlayerIdentity _identity;

        private void Start()
        {
            var health = GetComponent<IHealth>();
            if (health != null)
                Construct(health);

            var coins = GetComponent<ICoins>();
            if (coins != null)
                Construct(coins);

            var identity = GetComponent<PlayerIdentity>();
            if (identity != null)
                Construct(identity);
        }

        private void OnDestroy()
        {
            if (_health != null)
                _health.HealthChanged -= UpdateBar;
        }

        private void Construct(IHealth health)
        {
            _health = health;

            _health.HealthChanged += UpdateBar;
        }

        private void UpdateBar() =>
            _healthBar.SetValue(_health.Current, _health.Max);

        private void Construct(ICoins coins)
        {
            _coins = coins;

            _coins.CoinsChanged += UpdateCoinDisplayCount;
        }

        private void UpdateCoinDisplayCount() => 
            _coinDisplay.SetValue(_coins.Current);

        private void Construct(PlayerIdentity identity)
        {
            _identity = identity;
            _identity.NameChanged += UpdateDisplayName;
        }

        private void UpdateDisplayName() => 
            _nameDisplay.SetValue(_identity.Name);
    }
}