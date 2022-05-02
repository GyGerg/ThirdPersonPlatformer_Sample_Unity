using System;
using UniRx;
using UnityEngine;

namespace DefaultNamespace
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private int value;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                MessageBroker.Default.Publish(new PointsGained(value));
            }
        }
    }
}