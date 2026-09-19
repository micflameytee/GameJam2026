using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public string LevelName;
    void Update()
    {
        if (Time.frameCount % 10 == 0)
        {
            SpinDNA();
        }
    }

    void SpinDNA()
    {
        bool left = false;

        if(left == false)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            left = true;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            left = false;
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
