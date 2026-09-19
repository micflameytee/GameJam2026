using UnityEngine;

public class LevelChange : Monobehaviour
{
    
    private void OnTriggerEnter2D(Collider2D col){
           if (col.gameObject.tag == "Player")
            SceneManager.LoadScene();
    }
}
