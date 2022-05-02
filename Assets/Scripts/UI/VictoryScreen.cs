using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup group;
        [SerializeField] private float fadeTime;
        [SerializeField] private Button backToMenuButton;

        public static VictoryScreen Instance;

        private void Start()
        {
            Instance = this;
        }

        public void Show(bool show)
        {
            group.LeanAlpha(show ? 1f : 0f, fadeTime);
            group.interactable = show;
            group.blocksRaycasts = show;
            if (show)
            {
                Cursor.lockState = CursorLockMode.None;
                backToMenuButton.onClick.AddListener(UiManager.BackToMenu);
            }
            else
            {
                backToMenuButton.onClick.RemoveListener(UiManager.BackToMenu);
            }
        }
    }