using FutureArt.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace FutureArt.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] List<TextFadeController> _fadeControllers;

        void Start()
        {
            foreach (var item in _fadeControllers)
            {
                item.StartFadeIn();
            }
        }
    }
}