using TMPro;
using UnityEngine;

public class TotalCreatures : MonoBehaviour
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
        // Update with the number of creatures
        text.text = persistent.numCreatures.ToString();
    }
}