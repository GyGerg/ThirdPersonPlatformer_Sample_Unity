using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup group;
        [SerializeField] private float fadeTime;
        [SerializeField] private Button restartButton, backToMenuButton;

        public static GameOverScreen Instance;

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
                restartButton.onClick.AddListener(UiManager.Restart);
                backToMenuButton.onClick.AddListener(UiManager.BackToMenu);
            }
            else
            {
                restartButton.onClick.RemoveListener(UiManager.Restart);
                backToMenuButton.onClick.RemoveListener(UiManager.BackToMenu);
            }
        }
    }