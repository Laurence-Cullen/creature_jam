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
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If other collider is a creature
        if (other.gameObject.CompareTag("Creature"))
        {
            if (creature.ReadyToReproduce())
            {
                creature.Proposition(other.gameObject.GetComponent<Creature>());
            }
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        // If the other collider is Corpse or Plant and creature is not idle
        if ((other.gameObject.CompareTag("Corpse") || other.gameObject.CompareTag("Plant")) && !creature.IsIdle())
        {
            // If collider is Plant
            if (other.gameObject.CompareTag("Plant"))
            {
                Plant plant = other.gameObject.GetComponent<Plant>();

                // If plant is Nibbleable
                if (plant.Nibbleable())
                {
                    // If hunger greater than 30 then navigate to plant
                    if (creature.hunger > navigateToPlantHungerThreshold)
                    {
                        // Navigate creature to plant
                        creature.UpdateTargetLocation(plant.transform.position);
                    }
                }
            }
            else if (other.gameObject.CompareTag("Corpse") && creature.cannibalistic)
            {
                Corpse corpse = other.gameObject.GetComponent<Corpse>();

                // If corpse is not nibbled
                if (corpse.Nibbleable())
                {
                    // If hunger greater than 30 then navigate to plant
                    if (creature.hunger > navigateToCorpseHungerThreshold)
                    {
                        // Navigate creature to corpse
                        creature.UpdateTargetLocation(corpse.transform.position);
                    }
                }
            }
        }
    }
}