using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using TMPro;

    public class VelocityComponent : MonoBehaviour
    {
        

        [SerializeField] private string baseText = "Speed: ";
        [SerializeField] private TextMeshProUGUI textComponent;
        private async void Awake()
        {
            await UniTask.WaitUntil(() => GameManager.Instance != null && GameManager.Instance.player != null);
            var speed = GameManager.Instance.player
                .ObserveEveryValueChanged(p => p.Rb.velocity.magnitude).ToReactiveProperty();
            speed.Subscribe(spd =>
            {
                textComponent.text = $"{baseText}{spd}";
            }).AddTo(this);
        }
    }