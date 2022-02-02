using FutureArt.Utilities;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FutureArt.Menu
{
    public class SplashController : MonoBehaviour
    {
        #region Fields

        [SerializeField] List<TextFadeController> _fadeControllers;
        [SerializeField] TextFadeController _fadeControllerClickAnywhere;

        bool _splashFinishedFadeIn = false;
        bool _isExitingScene = false;

        #endregion Fields

        #region Unity

        void Start()
        {
            foreach (var item in _fadeControllers)
                item.StartFadeIn();
        }

        void Update()
        {
            if (!_splashFinishedFadeIn || _isExitingScene)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                foreach (var item in _fadeControllers)
                    item.StartFadeOut();

                _fadeControllerClickAnywhere.StartFadeOut();

                _isExitingScene = true;
            }
        }

        #endregion Unity

        #region Methods

        public void OnSplashFadeInFinished()
        {
            _splashFinishedFadeIn = true;
            _fadeControllerClickAnywhere.StartFadeIn();
        }

        public void OnSplashFadeOutFinished()
        {
            SceneManager.LoadScene(1);
        }

        #endregion Methods
    }
}