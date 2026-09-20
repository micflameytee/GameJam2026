using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button StartButton;
    public Button EndButton;

    private void Start()
    {
        StartButton.onClick.AddListener(LoadGame);
        EndButton.onClick.AddListener(QuitGame);
    }
    public void LoadGame()
    {
        SceneManager.LoadSceneAsync("Cambrian");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
