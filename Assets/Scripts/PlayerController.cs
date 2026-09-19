using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool FreeMovement = false;
    
    public PlayerControls Inputs;
    public Rigidbody2D rb2D;
    
    public float moveSpeed = 1f;
    public float jumpHeight = 10f;

    public int PlayerVal;
    
    private Vector2 _moveDirection;
    private Vector2 _jumpDirection;
    private Rigidbody2D rigidbody;

    public void Update()
    {
        if (_moveDirection.sqrMagnitude > 0f)
        {
            float angle = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg - 90f;
            
        }
    }


    private void Awake()
    {
        Inputs = new PlayerControls();
        Inputs.GamePlay.FreeMove.performed += HandleMove;
        Inputs.GamePlay.FreeMove.canceled += HandleMove;
        //Inputs.GamePlay.Jump.performed += HandleJump;
        //Inputs.GamePlay.Jump.canceled += HandleJump;
        Inputs.Enable();

        Debug.Log("PlayerController::Awake");
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(_moveDirection.normalized * moveSpeed, ForceMode2D.Impulse);
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        if (FreeMovement)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }
        else
        {
            _moveDirection.x = context.ReadValue<Vector2>().x;
            float verticalSpeed = rb2D.linearVelocity.y;
            if (verticalSpeed == 0f)
            {
                _jumpDirection.y = context.ReadValue<Vector2>().y;
                rigidbody.AddForce(_jumpDirection.normalized * jumpHeight, ForceMode2D.Impulse);
            }
        }
        Debug.Log(_moveDirection);
    }

    // private void HandleJump(InputAction.CallbackContext context)
    // {
    //     if (!FreeMovement)
    //     {
    //         _moveDirection.y = context.ReadValue<Vector2>().y;
    //         rigidbody.AddForce(_moveDirection.normalized * moveSpeed, ForceMode2D.Impulse);
    //     }
    // }
}
