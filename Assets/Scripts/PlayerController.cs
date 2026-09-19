using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool FreeMovement = false;
    
    public PlayerControls Inputs;
    
    public float moveSpeed = 5f;

    public int PlayerVal;
    
    private Vector2 _moveDirection;
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
        Inputs.GamePlay.Move.performed += HandleMove;
        Inputs.Enable();
        Debug.Log("PlayerController::Awake");
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
        rigidbody.AddForce(_moveDirection.normalized * moveSpeed, ForceMode2D.Impulse);
        Debug.Log(_moveDirection);
    }
}
