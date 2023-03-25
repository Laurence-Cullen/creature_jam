using System.Collections;
using System.Collections.Generic;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        // If the other collider is a plant nibble it
        if (other.gameObject.CompareTag("Plant"))
        {
            // If parent hunger greater than nibbleHungerLoss then nibble
            if (creature.hunger > creature.nibbleHungerLoss)
            {
                Plant plant = other.gameObject.GetComponent<Plant>();

                // Call NibblePlant on parent
                creature.NibblePlant(plant);
            }
        }
    }
}