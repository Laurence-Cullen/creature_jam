using TMPro;
using UnityEngine;

public class GenerationsDisplay : MonoBehaviour
{
    // Persistent
    public Persistent persistent;

    // TextMeshPro UI
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        persistent = GameObject.FindWithTag("Persistent").GetComponent<Persistent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the display with the number of generations
        text.text = persistent.generations.ToString();
    }
}