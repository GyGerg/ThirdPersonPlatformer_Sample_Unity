using System;
using UnityEngine;

    public class TurnOffJumpOnPlayer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerJump>().enabled = false;
            }
        }
    }