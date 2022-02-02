using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace FutureArt.Utilities
{
    public class TextFadeController : MonoBehaviour
    {
        #region Fields

        public UnityEvent FadeInFinished;
        public UnityEvent FadeOutFinished;

        [SerializeField] float _fadeInDurationInSeconds = 1;
        [SerializeField] float _fadeOutDurationInSeconds = 1;

        [SerializeField] TextMeshProUGUI _text;

        bool _isFading = false;

        #endregion Fields

        #region Unity

        void Awake()
        {
            if (_text == null)
                _text = GetComponent<TextMeshProUGUI>();
        }

        #endregion Unity

        #region Methods

        public void StartFadeIn()
        {
            StartCoroutine(Fade(0, 1, _fadeInDurationInSeconds));
        }

        public void StartFadeOut()
        {
            if (!_isFading)
                StartCoroutine(Fade(1, 0, _fadeOutDurationInSeconds));
        }

        IEnumerator Fade(float beginVal, float endVal, float duration)
        {
            _isFading = true;

            Color color = _text.color;
            float elapsedTime = 0;
            float waitTime = .1f;
            float alphaValue = beginVal;

            //while (_text.color.a < 0.99f)
            while (alphaValue != endVal)
            {
                var aux = gameObject.name;

                elapsedTime += waitTime;

                float step = elapsedTime / duration;
                alphaValue = Mathf.Lerp(beginVal, endVal, step);

                color.a = alphaValue;
                _text.color = color;

                yield return new WaitForSeconds(waitTime);
            }

            if (beginVal < endVal)
                FadeInFinished.Invoke();
            else
                FadeOutFinished.Invoke();

            _isFading = false;
        }

        #endregion Methods
    }
}