using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 5f;
    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.Victory();
        }
    }
}
