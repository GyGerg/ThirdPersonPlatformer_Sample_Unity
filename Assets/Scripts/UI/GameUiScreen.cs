using System;
using UnityEngine;

    public class GameUiScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private float _fadeDuration = 0.5f;
        public static GameUiScreen Instance;

        private void Start()
        {
            Instance = this;
        }

        public void Show(bool show)
        {
            _group.LeanAlpha(show ? 1f : 0f, _fadeDuration);
            var mouselook = FindObjectOfType<MouseLook>();
            if(mouselook != null) mouselook.enabled = show;
            
        }
    }