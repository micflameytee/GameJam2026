using System.Collections;
using UnityEngine;

public class BranchFall : MonoBehaviour
{
    public Rigidbody2D rb;

    private bool _hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_hasTriggered)
        {
            _hasTriggered = true;
            StartCoroutine(FallAfterDelay(3.0f));
        }
    }

    private IEnumerator FallAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Debug.Log($"player");
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}