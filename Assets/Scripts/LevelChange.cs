using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public string LevelName;
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

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"DNA Triggered");
        SceneManager.LoadScene("Jurassic");
        SceneManager.UnloadScene("Cambrian");
    }
}
