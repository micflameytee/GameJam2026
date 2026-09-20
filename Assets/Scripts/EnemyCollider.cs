using System;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"interact {other.name}");
        if (other.CompareTag("Player"))
        {
            var startPos = GameObject.Find("SpawnPoint");
            if (startPos == null)
            {
                throw new Exception("Start point not found");
            }
            
            other.transform.position = startPos.transform.position;
        }
    }
}
