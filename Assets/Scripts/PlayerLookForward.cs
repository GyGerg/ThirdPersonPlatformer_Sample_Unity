using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;

[RequireComponent(typeof(PlayerController))]
public class PlayerLookForward : MonoBehaviour
    {
        [SerializeField] private Transform lookTransform;
        [SerializeField] float sensitivity = 1f;
        private PlayerInput PlayerInput => _playerController.playerInput;
        private PlayerController _playerController;
        
        private Rigidbody Rb => _playerController.Rb;

        private Vector2 _move;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
        }

        private void FixedUpdate()
        {
            if (_move == Vector2.zero) return;
            var lookRotation = Quaternion.LookRotation(lookTransform.forward);
            var localEuler = lookRotation.eulerAngles;
            localEuler.x = 0;
            lookRotation = Quaternion.Euler(localEuler);
            
            Rb.MoveRotation(Quaternion.Slerp(Rb.rotation, lookRotation, Time.fixedDeltaTime * sensitivity));
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            _move = ctx.ReadValue<Vector2>();
        }

        private void OnEnable()
        {
            var moveAction = PlayerInput.actions["Move"];
            moveAction.started += OnMove;
            moveAction.performed += OnMove;
            moveAction.canceled += OnMove;
        }

        private void OnDisable()
        {
            Unsub();
        }

        private void Unsub()
        {
                if (PlayerInput == null || PlayerInput.actions["Move"] == null) return;
                var moveAction = PlayerInput.actions["Move"];
                moveAction.started -= OnMove;
                moveAction.performed -= OnMove;
                moveAction.canceled -= OnMove;
        }

        private void OnDestroy()
        {
            Unsub();
        }
    }