using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : BaseMovement
{
    [SerializeField] private InputActionAsset _inputAction;
    
    private InputAction _movementInput;

    private void OnEnable()
    {
        _inputAction.FindActionMap("Gameplay").Enable();
    }
    private void OnDisable()
    {
        _inputAction.FindActionMap("Gameplay").Disable();
    }

    protected override void Awake()
    {
        base.Awake();

        FindInputs();
    }

    private void FindInputs()
    {
        _movementInput = InputSystem.actions.FindAction("Movement");
    }

    private void FixedUpdate()
    {
        MoveObject(_movementInput.ReadValue<Vector2>());
    }
    
}
