using System;
using UnityEngine;

    public class TurnOnJumpOnPlayer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerJump>().enabled = true;
            }
        }
    }