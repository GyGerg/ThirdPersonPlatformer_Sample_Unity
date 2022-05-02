using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerController))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput PlayerInput => (_playerController ??= GetComponent<PlayerController>()).playerInput;
    private Rigidbody Rb => _playerController.Rb;
    private PlayerController _playerController;

    [SerializeField] private float speed = 2f;

    private bool _doubleJumped;

    private Vector2 _move;

    void OnEnable()
    {
        var moveAction = PlayerInput.actions["Move"];
        moveAction.performed += OnMove;
        moveAction.started += OnMove;
        moveAction.canceled += OnMove;
    }

    void OnDisable()
    {
        Unsub();
    }

    void OnDestroy()
    {
        Unsub();
    }

    void Unsub()
    {
        if (PlayerInput == null || PlayerInput.actions["Move"] == null)
            return;
        var moveAction = PlayerInput.actions["Move"];
        moveAction.performed -= OnMove;
        moveAction.started -= OnMove;
        moveAction.canceled -= OnMove;
    }

    void OnMove(InputAction.CallbackContext ctx)
    {
        _move = ctx.ReadValue<Vector2>();
    }
    
    void FixedUpdate()
    {
        Rb.AddRelativeForce(new Vector3(_move.x, 0, _move.y) * speed, ForceMode.Impulse);
    }
}

public static partial class Extensions
{
    public static IObservable<InputAction.CallbackContext> PerformedAsObservable(this InputAction action)
    {
        return Observable.FromEvent<InputAction.CallbackContext>(
            h => action.performed += h,
            h => action.performed -= h);
    }

    public static IObservable<InputAction.CallbackContext> StartedAsObservable(this InputAction action)
    {
            return Observable.FromEvent<InputAction.CallbackContext>(
            h => action.started += h,
            h => action.started -= h);
    }

    public static IObservable<InputAction.CallbackContext> CanceledAsObservable(this InputAction action)
    {
        return Observable.FromEvent<InputAction.CallbackContext>(
            h => action.canceled += h,
            h => action.canceled -= h);
    }

    public static IObservable<InputAction.CallbackContext> AnyAsObservable(this InputAction action)
    {
        return action.StartedAsObservable().Merge(action.PerformedAsObservable()).Merge(action.CanceledAsObservable());
    }
}
