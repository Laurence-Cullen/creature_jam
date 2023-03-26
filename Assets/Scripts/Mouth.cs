using UnityEngine;

public class Mouth : MonoBehaviour
{
    // Parent
    Creature creature;

    // Start is called before the first frame update
    void Start()
    {
        creature = transform.parent.GetComponent<Creature>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // If the other collider is edible nibble it
        if (other.gameObject.CompareTag("Edible"))
        {
            // If creature hunger greater than nibbleHungerLoss then nibble
            if (creature.hunger > creature.nibbleHungerLoss)
            {
                // If plant
                if (other.gameObject.CompareTag("Plant"))
                {
                    other.gameObject.GetComponent<Plant>().Nibbled();
                }
                else if (other.gameObject.CompareTag("Corpse"))
                {
                    other.gameObject.GetComponent<Corpse>().Nibbled();
                }
            }
        }
    }
}