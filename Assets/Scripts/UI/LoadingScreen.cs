using System.Collections;
using UnityEngine;

namespace UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private float _curtainAlphaFade = 0.03f;
        [SerializeField] private float _timeToFade = 0.03f;
        [SerializeField] private CanvasGroup _loadingScreenPrefab;

        private void Awake() => 
            DontDestroyOnLoad(this);

        public void Show()
        {
            gameObject.SetActive(true);
            _loadingScreenPrefab.alpha = 1;
        }

        public void Hide() =>
            StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            while (_loadingScreenPrefab.alpha > 0)
            {
                _loadingScreenPrefab.alpha -= _curtainAlphaFade;
                yield return new WaitForSeconds(_timeToFade);
            }

            gameObject.SetActive(false);
        }
    }
}