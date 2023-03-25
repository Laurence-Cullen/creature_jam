using UnityEngine;

public class Creature : MonoBehaviour
{
    // Vision collider
    public CircleCollider2D visionCollider;
    public float speed = 10;
    public Rigidbody2D rb;
    private Vector2 TargetLocation;

    // Hunger level
    public float hunger = 0;

    // Maximum hunger level
    public float maxHunger = 100;

    // Hunger gain per second
    public float hungerGain = 1;

    // Hunger loss from nibbling a plant
    public float nibbleHungerLoss = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Set the target location to a random location
        TargetLocation = GetRandomLocation();
    }

    Vector2 GetRandomLocation()
    {
        // Picks a location to move to from somewhere within the viewport
        Vector3 targetLocationViewport = new Vector3(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), 0);
        Vector3 targetLocationWorld = Camera.main.ViewportToWorldPoint(targetLocationViewport);

        // Convert to 2D vector
        Vector2 target2D = new Vector2(targetLocationWorld.x, targetLocationWorld.y);

        return target2D;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the target location has been reached
        if (Vector2.Distance(transform.position, TargetLocation) < 0.1f)
        {
            // If so, pick a new target location
            TargetLocation = GetRandomLocation();
        }


        // Increase hunger
        hunger += hungerGain * Time.deltaTime;

        // Move towards the target location
        rb.position = Vector2.MoveTowards(rb.position, TargetLocation, speed * Time.deltaTime);
    }

    public void NavigateToPlant(Plant plant)
    {
        // Set the target location to the plant's position
        TargetLocation = plant.transform.position;
    }

    public void NibblePlant(Plant plant)
    {
        // Nibble the plant
        plant.Nibbled();

        // Reduce hunger
        hunger -= nibbleHungerLoss;

        // Set the target location to a random location
        TargetLocation = GetRandomLocation();
    }
}