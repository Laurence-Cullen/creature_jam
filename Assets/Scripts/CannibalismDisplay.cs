using UnityEngine;

public class CannibalismDisplay : MonoBehaviour
{
    // Persistent
    public Persistent persistent;

    // Y object
    public GameObject y;

    // N object
    public GameObject n;

    // Start is called before the first frame update
    void Start()
    {
        persistent = GameObject.FindWithTag("Persistent").GetComponent<Persistent>();
    }

    // Update is called once per frame
    void Update()
    {
        // If cannibalism is enabled display y otherwise display n
        if (persistent.cannibalism)
        {
            y.SetActive(true);
            n.SetActive(false);
        }
        else
        {
            y.SetActive(false);
            n.SetActive(true);
        }
    }
}