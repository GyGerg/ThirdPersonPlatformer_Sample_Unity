using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

    public class PointsComponent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pointsText;
        [SerializeField] private string baseText = "Points: ";

        private void Awake()
        {
            GameManager.Instance.Score.Subscribe(points => pointsText.text = $"{baseText}{points}").AddTo(this);
        }
    }