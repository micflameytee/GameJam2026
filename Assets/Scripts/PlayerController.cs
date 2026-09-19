using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool FreeMovement = false;
    public bool FreeJump = false;

    Boolean faceRight = true;
    
    public PlayerControls Inputs;
    public Rigidbody2D rb2D;

    
    public float moveSpeed = 1f;
    public float jumpHeight = 10f;

    
    private Vector2 _moveDirection;
    private Vector2 _jumpDirection;
    private Rigidbody2D rigidbody;
    private bool _CollisionOccurred;
    public SpriteRenderer spriteRenderer;


    public Transform wallCheckPos;
    public Vector2 wallCheckSize = new Vector2(0.49f, 0.03f);
    public LayerMask WallLayer;
    

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
        Inputs.Enable();

        Debug.Log("PlayerController::Awake");
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // _CollisionOccurred = false;
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
            _jumpDirection.y = context.ReadValue<Vector2>().y;
            

            if (verticalSpeed == 0f && (FreeJump || WallCheck()))
            {
                rigidbody.AddForce(_jumpDirection.normalized * jumpHeight, ForceMode2D.Impulse);
            }

        }

        if (faceRight && context.ReadValue<Vector2>().x < 0f)
        {
            faceRight = false;
            flip(faceRight);
        }else if(!faceRight && context.ReadValue<Vector2>().x > 0f)
        {
            faceRight = true;
            flip(faceRight);
        }
        // Debug.Log(_moveDirection);
    }

    private Boolean WallCheck()
    {
        Debug.Log(Physics2D.OverlapBox(wallCheckPos.position, wallCheckSize, 0, WallLayer));
        return Physics2D.OverlapBox(wallCheckPos.position, wallCheckSize, 0, WallLayer);
    }

    void flip(Boolean doFlip)
    {
        // Debug.Log(doFlip);
        spriteRenderer.flipX = doFlip;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(wallCheckPos.position, wallCheckSize);
    }
}
