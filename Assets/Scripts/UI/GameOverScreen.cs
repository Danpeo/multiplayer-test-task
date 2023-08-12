using TMPro;
using UnityEngine;

namespace UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameDisplay;
        [SerializeField] private TMP_Text _coinDisplay;

        private void Awake() =>
            DontDestroyOnLoad(this);

        public void SetName(string playerName) =>
            _nameDisplay.text = $"Player {playerName} won!!!";

        public void SetCoins(string value) =>
            _coinDisplay.text = $"Collected {value} coins!!!";

        public void Show() =>
            gameObject.SetActive(true);
    }
}