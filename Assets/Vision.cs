using UnityEngine;

public class Vision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Called when the vision collider enters another collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Print to console the name of the other collider
        Debug.Log(other.gameObject.name);

        // // If the other collider is a plant
        // if (other.gameObject.CompareTag("Plant"))
        // {
        //     // Get the plant component
        //     Plant plant = other.gameObject.GetComponent<Plant>();
        //     // Nibble the plant
        //     plant.Nibbled();
        // }
    }
}