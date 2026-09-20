using System;
using UnityEngine;

[RequireComponent(typeof(EnemyCollider))]
public class HostileManager : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 3f;
    private int direction = 1;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;


    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed * direction, rb.linearVelocity.y);
        ChangeDirection();
    }

    public void ChangeDirection()
    {
        if (direction == -1 && this.transform.position.x < startPoint.position.x)
        {
            direction = 1;
        }else if (direction == 1 && this.transform.position.x > endPoint.position.x)
        {
            direction = -1;
        }
    }
}
