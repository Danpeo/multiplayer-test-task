using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinDisplayCount : MonoBehaviour
    {
        [SerializeField] private TMP_Text _displayText;

        public void SetValue(int value)
        {
            _displayText.text = value.ToString();
        }
    }
}