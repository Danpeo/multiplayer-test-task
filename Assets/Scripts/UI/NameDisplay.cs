using TMPro;
using UnityEngine;

namespace UI
{
    public class NameDisplay: MonoBehaviour
    {
        [SerializeField] private TMP_Text _displayText;

        public void SetValue(string value)
        {
            _displayText.text = value;
        }
    }
}