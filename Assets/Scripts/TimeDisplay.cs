using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
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
        // Update the time display with the current time to 2 decimal places
        text.text = persistent.time.ToString("F2");
    }
}