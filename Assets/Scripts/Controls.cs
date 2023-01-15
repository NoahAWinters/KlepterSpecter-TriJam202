using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Controls : MonoBehaviour
{
    private static Controls instance;
    PlayerControls _playerControls;

    Vector2 _move;
    bool _grab;
    bool _dash;

    public float MoveX { get { return _move.x; } }
    public float MoveY { get { return _move.y; } }
    public bool Grab { get { return _grab; } }
    public bool Dash { get { return _dash; } }

    void Awake()
    {
        if (instance != null)
        {
            //Debug.LogWarning("Found more than 1 Controller in scene");
        }
        instance = this;

        _playerControls = new PlayerControls();

        _playerControls.Gameplay.Move.started += OnMovementInput;
        _playerControls.Gameplay.Move.performed += OnMovementInput;
        _playerControls.Gameplay.Move.canceled += OnMovementInput;

        _playerControls.Gameplay.Grab.performed += OnGrabInput;

        _playerControls.Gameplay.Dash.performed += OnDashInput;
    }

    void OnEnable()
    {
        _playerControls.Gameplay.Enable();
    }

    void OnDisable()
    {
        _playerControls.Gameplay.Disable();
    }


    void OnMovementInput(InputAction.CallbackContext ctx) //Set if movemnet has been triggered
    {
        Vector2 moveInput = ctx.ReadValue<Vector2>();
        //_currMoveInput.Normalize();
        moveInput = Vector2.ClampMagnitude(moveInput, 1f);

        _move.x = moveInput.x;
        _move.y = moveInput.y;
    }

    void OnGrabInput(InputAction.CallbackContext ctx)
    {
        _grab = ctx.ReadValueAsButton();
    }
    void OnDashInput(InputAction.CallbackContext ctx)
    {
        _dash = ctx.ReadValueAsButton();
    }

    public static Controls GetInstance()
    {
        return instance;
    }
}
