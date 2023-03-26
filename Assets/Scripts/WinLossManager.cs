using UnityEngine;

public class WinLossManager : MonoBehaviour
{
    // Win GameObject
    public GameObject win;

    // Lose GameObject
    public GameObject lose;

    // Game won
    public bool gameWon = false;


    // Start is called before the first frame update
    void Start()
    {
        // If game won disable lose
        if (gameWon)
        {
            lose.SetActive(false);
        }
        else // Else disable win
        {
            win.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}