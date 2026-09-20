using UnityEngine;

public class BranchDamage : MonoBehaviour
{
    
    public Transform startPosition;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log($"player", other.gameObject);
        if (other.CompareTag("Player"))
        {
            Debug.Log($"player moving");
            // other.enabled = false;
            other.transform.position = startPosition.position;
            // other.enabled = true;
        }
    }

}
