using UnityEngine;

public class StartButton : MonoBehaviour
{
    // Score tracker GameObject
    public GameObject scoreTracker;

    // PreStartMenu GameObject
    public GameObject preStartMenu;

    // Start
    void Start()
    {
        // Disable ScoreTracker
        scoreTracker.SetActive(false);
    }


    // Start the game on click
    public void StartExperiment()
    {
        // Set game timescale to 0
        Time.timeScale = 1;

        // Set ScoreTracker to active
        scoreTracker.SetActive(true);

        // Disable PreStartMenu
        preStartMenu.SetActive(false);
    }
}