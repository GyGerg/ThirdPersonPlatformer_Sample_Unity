using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using TMPro;

    public class ScoreComponent : MonoBehaviour
    {
        

        [SerializeField] private string baseText = "Score: ";
        [SerializeField] private TextMeshProUGUI textComponent;
        private async void Awake()
        {
            await UniTask.WaitUntil(() => GameManager.Instance != null && GameManager.Instance.player != null);
            GameManager.Instance.Score.Subscribe(score =>
            {
                textComponent.text = $"{baseText}{score}";
            }).AddTo(this);
        }
    }