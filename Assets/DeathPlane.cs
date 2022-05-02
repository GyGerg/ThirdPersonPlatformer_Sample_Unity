using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.Instance.KillPlayer();
        else if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
