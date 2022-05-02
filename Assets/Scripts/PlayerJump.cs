using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

    [RequireComponent(typeof(PlayerController))]
    public class PlayerJump : MonoBehaviour
    {
        
        private PlayerInput PlayerInput => _playerController.playerInput;

        private bool IsGrounded
        {
            get
            {
                var grounded = _playerController.IsGrounded;

                if (grounded && _doubleJumped)
                {
                    _doubleJumped = false;
                }

                return grounded;
            }
        }
        private bool _doubleJumped;
        [SerializeField] private float jumpForce = 150f;
        private Rigidbody Rb => _playerController.Rb;
        private PlayerController _playerController;

        void Awake()
        {
            _playerController ??= GetComponent<PlayerController>();
        }

        async void OnJump(InputAction.CallbackContext ctx)
        {
            await UniTask.WaitForFixedUpdate();
            var grounded = IsGrounded;
            if (grounded || !_doubleJumped)
            {
                var vel = Rb.velocity;
                Rb.velocity = new Vector3(vel.x, 0, vel.z);
                Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            _doubleJumped = !grounded;
        }

        private void OnEnable()
        {
            Debug.Log("Jump component enabled.");
            PlayerInput.actions["Jump"].started += OnJump;
            _doubleJumped = false;
        }

        private void OnDisable()
        {
            Unsub();
        }

        private void OnDestroy()
        {
            Unsub();
        }

        private void Unsub()
        {
            
            Debug.Log("Jump component disabled.");
            if (PlayerInput == null || PlayerInput.actions["Jump"] == null) return;
            PlayerInput.actions["Jump"].started -= OnJump;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_doubleJumped)
            {
                _doubleJumped = !IsGrounded; // if isgrounded is false then we just set it to true, aka no change
                                            // else we set it to false, aka we can doubleJump next time
            }
        }
    }