using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
        public PlayerInput playerInput;
        [SerializeField] private Rigidbody rb;
        public Rigidbody Rb => rb;
        public bool IsGrounded => Physics.Raycast(transform.position, Vector3.down, 1.02f);

        private void Awake()
        {
                rb ??= GetComponent<Rigidbody>();
        }


        private void OnCollisionEnter(Collision coll)
        {
                if (coll.gameObject.CompareTag("Enemy"))
                {
                        if (Vector3.Dot((transform.position - coll.transform.position).normalized, Vector3.up) > 0.6f)
                        {
                                GameManager.Instance.KillEnemy(coll.gameObject.GetComponent<EnemyController>());
                                
                        }
                        else
                        {
                                GameManager.Instance.KillPlayer();
                        }
                }
        }
}