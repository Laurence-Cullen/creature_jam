using UnityEngine;

public class WinLossManager : MonoBehaviour
{
    // Persistent
    public Persistent persistent;

    // Win GameObject
    public GameObject win;

    // Lose GameObject
    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    {
        persistent = GameObject.FindWithTag("Persistent").GetComponent<Persistent>();

        // If game won disable lose
        if (persistent.win)
        {
            lose.SetActive(false);
        }
        else // Else disable win
        {
            win.SetActive(false);
        }
    }
}