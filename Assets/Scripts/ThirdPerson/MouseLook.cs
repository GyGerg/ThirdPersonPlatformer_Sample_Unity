using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UniRx;

    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private Transform lookTransform;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private float sensitivity = 1f;
        
        [SerializeField] Sprite cursorSprite;

        private Vector2 _look;
        void Awake()
        {
            // Cursor.SetCursor(cursorSprite.texture, Vector2.zero, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.Locked;
            
            playerInput.actions["Escape"].PerformedAsObservable().Where(_ => Cursor.lockState == CursorLockMode.Locked)
                .Subscribe(_ => Cursor.lockState = CursorLockMode.None).AddTo(this);

            playerInput.actions["Look"].PerformedAsObservable()
                .Subscribe(ctx =>
                {
                    _look = ctx.ReadValue<Vector2>();
                    var rot = lookTransform.rotation;
                    rot *= Quaternion.AngleAxis(_look.x * sensitivity * Time.deltaTime, Vector3.up);

                    rot *= Quaternion.AngleAxis(-_look.y * sensitivity * Time.deltaTime, Vector3.right);
                    lookTransform.rotation = rot;
                    var angles = lookTransform.localEulerAngles;

                    angles.z = 0;

                    angles.x = angles.x switch
                    {
                        > 180 and < 340 => 340,
                        < 180 and > 40 => 40,
                        _ => angles.x
                    };

                    lookTransform.localEulerAngles = angles;
                }).AddTo(this);
        }
    }