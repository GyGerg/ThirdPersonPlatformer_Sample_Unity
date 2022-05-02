using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpForce = 500f;

    private void OnCollisionEnter(Collision other)
    {
        Handle(other.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        Handle(other);
    }

    private void Handle(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
