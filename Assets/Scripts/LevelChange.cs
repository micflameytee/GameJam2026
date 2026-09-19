using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    private void OnTriggerCollider2D(Collider2D col){
        if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("");
        }
    }
}
