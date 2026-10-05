using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }

    public event Action JumpPressed;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;

    void Awake()
    {
        UnityEngine.InputSystem.PlayerInput playerInput = GetComponent<UnityEngine.InputSystem.PlayerInput>();
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        jumpAction = playerInput.actions["Jump"];
    }

    void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        jumpAction.Enable();
        jumpAction.performed += OnJumpPerformed;
    }

    void OnDisable()
    {
        jumpAction.performed -= OnJumpPerformed;
        moveAction.Disable();
        lookAction.Disable();
        jumpAction.Disable();
    }

    void Update()
    {
        MoveInput = moveAction.ReadValue<Vector2>();
        LookInput = lookAction.ReadValue<Vector2>();
    }

    private void OnJumpPerformed(InputAction.CallbackContext ctx)
    {
        JumpPressed?.Invoke();
    }
}