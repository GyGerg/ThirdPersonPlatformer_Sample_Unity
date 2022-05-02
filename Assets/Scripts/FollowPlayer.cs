using System;
using UnityEngine;
using Cysharp.Threading.Tasks.Linq;
using UniRx;

public class FollowPlayer : MonoBehaviour
    {
        public Transform player;

        private void Update()
        {
            if (player == null) return;
            transform.position = player.position;
        }
    }