using Pathfinding;
using UnityEngine;

public class Creature : MonoBehaviour
{
    // Access Camera
    public Camera camera;
    
    // AI Destination Setter
    public AIDestinationSetter aiDestinationSetter;

    // Hunger level
    public float hunger = 0;

    // Maximum hunger level
    public float maxHunger = 100;

    // Hunger gain per second
    public float hungerGain = 1;

    // Hunger loss from nibbling a plant
    public float nibbleHungerLoss = 10;

    // Target buffer
    public float targetBuffer = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // Set camera
        camera = Camera.main;

        // Create transform from random location
        aiDestinationSetter.target = new GameObject().transform;

        // Set the target location to a random location
        aiDestinationSetter.target.position = GetRandomLocation();
    }

    Vector3 GetRandomLocation()
    {
        // Picks a location to move to from somewhere within the viewport
        float cameraZ = camera.transform.position.z;
        Vector3 targetLocationViewport = new Vector3(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), -cameraZ);

        Vector3 worldPoint = Camera.main.ViewportToWorldPoint(targetLocationViewport);


        // List all GameObjects with tage Water
        GameObject[] water = GameObject.FindGameObjectsWithTag("Water");

        // Loop through all GameObjects with tag Water
        foreach (GameObject waterObject in water)
        {
            // Check if the new target location is within the water collider
            if (waterObject.GetComponent<Collider2D>().bounds.Contains(worldPoint))
            {
                // If so, pick a new target location
                worldPoint = GetRandomLocation();
            }
        }

        // Print to console the new target location
        Debug.Log("New target location: " + worldPoint);
        return worldPoint;
    }

    void UpdateTargetLocation(Vector3 targetLocation)
    {
        // Create transform from random location
        aiDestinationSetter.target = new GameObject().transform;

        // Set the target location to a random location
        aiDestinationSetter.target.position = targetLocation;
    }

    // Update is called once per frame
    void Update()
    {
        // // Check if the target location has been reached
        if (Vector3.Distance(transform.position, aiDestinationSetter.target.position) < targetBuffer)
        {
            // If so, pick a new target location
            UpdateTargetLocation(GetRandomLocation());
        }

        // Increase hunger
        hunger += hungerGain * Time.deltaTime;
    }

    public void NavigateToPlant(Plant plant)
    {
        // Set the target location to the plant's position
        UpdateTargetLocation(plant.transform.position);

        // Navigating to plant
        Debug.Log("Navigating to plant");
    }

    public void NibblePlant(Plant plant)
    {
        // Nibble the plant
        plant.Nibbled();

        // Reduce hunger
        hunger -= nibbleHungerLoss;

        // Nibbled plant
        Debug.Log("Nibbled plant");

        // Set the target location to a random location
        UpdateTargetLocation(GetRandomLocation());
    }
}