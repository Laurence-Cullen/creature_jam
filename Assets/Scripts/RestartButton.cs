using UnityEngine;

public class RestartButton : MonoBehaviour
{
    // Controller
    public Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // On click restart the game
    public void OnClick()
    {
        // Clear the map
        controller.ClearMap();

        // Set game timescale to 0
        Time.timeScale = 0;
    }
}