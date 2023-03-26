using DefaultNamespace;
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
        // If the other collider is plant or corpse
        if (other.gameObject.CompareTag("Plant") || other.gameObject.CompareTag("Corpse"))
        {
            Edible edible = other.gameObject.GetComponent<Edible>();

            // If creature hunger greater than nibbleHungerLoss then nibble
            if (creature.hunger > creature.nibbleHungerLoss && edible.Nibbleable())
            {
                // If plant
                if (other.gameObject.CompareTag("Plant"))
                {
                    creature.NibblePlant(other.gameObject.GetComponent<Plant>());
                }
                else if (other.gameObject.CompareTag("Corpse"))
                {
                    creature.NibbleCorpse(other.gameObject.GetComponent<Corpse>());
                }
            }
        }
    }
}