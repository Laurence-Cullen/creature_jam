using UnityEngine;

public class Vision : MonoBehaviour
{
    // Parent
    Creature creature;
    
    // Navigate to plant hunger threshold
    public float navigateToPlantHungerThreshold = 30;

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
            // If hunger greater than 30 then navigate to plant
            if (creature.hunger > navigateToPlantHungerThreshold)
            {
                Plant plant = other.gameObject.GetComponent<Plant>();

                // Call NavigateToPlant on parent
                creature.NavigateToPlant(plant);
            }
        }
    }
}