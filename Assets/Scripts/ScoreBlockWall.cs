using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

public class ScoreBlockWall : MonoBehaviour
{
    [SerializeField] private int threshold;
    async void Awake()
    {
        await UniTask.WaitUntil(() => GameManager.Instance != null && GameManager.Instance.Score != null);

        GameManager.Instance.Score.Where(sc => sc >= threshold).Take(1).Subscribe(_ => Destroy(gameObject)).AddTo(this);
    }
}
