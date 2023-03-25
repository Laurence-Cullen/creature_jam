using UnityEngine;

public class Vision : MonoBehaviour
{
    // Parent
    Creature creature;

    // Start is called before the first frame update
    void Start()
    {
        // access parent
        creature = transform.parent.GetComponent<Creature>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Called when the vision collider enters another collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the other collider is a plant nibble it
        if (other.gameObject.CompareTag("Plant"))
        {
            Plant plant = other.gameObject.GetComponent<Plant>();
            
            // NavigateToPlant
            creature.NavigateToPlant(plant);
        }
    }
}