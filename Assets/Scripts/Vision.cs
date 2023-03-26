using UnityEngine;

public class Vision : MonoBehaviour
{
    // Parent
    Creature creature;

    // Navigate to plant hunger threshold
    public float navigateToPlantHungerThreshold = 30;

    public float navigateToCorpseHungerThreshold = 70;

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
    void OnTriggerStay2D(Collider2D other)
    {
        // If other collider is a creature
        if (other.gameObject.CompareTag("Creature"))
        {
            if (creature.ReadyToReproduce())
            {
                creature.Proposition(other.gameObject.GetComponent<Creature>());
            }
        }
        // If the other collider is edible nibble it
        else if (other.gameObject.CompareTag("Edible"))
        {
            // If hunger greater than 30 then navigate to plant
            if (creature.hunger > navigateToPlantHungerThreshold)
            {
                Plant plant = other.gameObject.GetComponent<Plant>();

                // Navigate creature to plant
                creature.UpdateTargetLocation(plant.transform.position);
            }
            else if (creature.hunger > navigateToCorpseHungerThreshold)
            {
                Corpse corpse = other.gameObject.GetComponent<Corpse>();

                // Navigate creature to corpse
                creature.UpdateTargetLocation(corpse.transform.position);
            }
        }
    }
}