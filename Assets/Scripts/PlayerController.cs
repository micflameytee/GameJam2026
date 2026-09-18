using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool FreeMovement = false;
    
    public float moveSpeed = 5f;

    public int PlayerVal;
    
    private Vector2 _moveDirection;
    
    
    public void HandleMovement(InputAction.CallbackContext context)
    {
        _moveDirection = context.readValue<Vector2>();
    }


    public void Update()
    {
        if (_moveDirection.sqrMagnitude > 0f)
        {
            float angle = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg - 90f;
        }
    }
}
