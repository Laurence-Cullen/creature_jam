using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditButton : MonoBehaviour
{
    // Menu 0 
    // MainScene 1
    // EndScene 2 
    // Credits 3
    // Start is called before the first frame update

    // Load Menu
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Load MainScene
    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    // Load EndScene
    public void LoadEndScene()
    {
        SceneManager.LoadScene(2);
    }

    // On click load the credits scene
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene(3);
    }
}