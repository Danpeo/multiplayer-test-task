using Logic;
using Player;
using UI;
using Object = UnityEngine.Object;

namespace Infrastructure.States
{
    public class GameOverState : IState
    {
        private readonly GameOverScreen _gameOverScreen;

        private string _playerName;
        private string _coinValue;

        public GameOverState()
        {
        }

        public GameOverState(PlayerDeath playerDeath, GameOverScreen gameOverScreen)
        {
            playerDeath.DeathOccured += OnPlayerDeath;
            _gameOverScreen = gameOverScreen;
        }

        public void Enter()
        {
            _gameOverScreen.SetName(_playerName);
            _gameOverScreen.SetCoins(_coinValue);
            _gameOverScreen.Show();
        }

        private void OnPlayerDeath()
        {
            var playerIdentities = Object.FindObjectsOfType<PlayerIdentity>();
            if (playerIdentities.Length <= 1)
            {
                _playerName = playerIdentities[0].Name;
                var coins = playerIdentities[0].GetComponent<ICoins>();
                _coinValue = coins.Current.ToString();

                Enter();
            }
        }

        public void Exit()
        {
        }
    }
}