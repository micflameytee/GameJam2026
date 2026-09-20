using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public string NextLevelName;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Time.frameCount % 30 == 0)
        {
            //Debug.Log($"SpinLeft");
            spriteRenderer.flipX = true;
         
        }

        if (Time.frameCount % 20 == 0)
        {
            //Debug.Log($"SpinRight");
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var startPos = GameObject.Find("SpawnPoint");
            if (startPos == null)
            {
                throw new Exception("Start point not found");
            }
        }
    }
}
