using Pathfinding;
using UnityEngine;

public class Creature : MonoBehaviour
{
    // AI Destination Setter
    public AIDestinationSetter aiDestinationSetter;

    // Hunger level
    public float hunger = 0;

    // Maximum hunger level
    public float maxHunger = 100;

    // Hunger gain per second
    public float hungerGain = 10;

    // Hunger loss from nibbling a plant
    public float nibbleHungerLoss = 10;

    // Target buffer
    public float targetBuffer = 0.2f;

    // Destination object
    private Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        destination = new GameObject().transform;

        // Create transform from random location
        aiDestinationSetter.target = destination;

        UpdateTargetLocation(GetRandomLocation());
    }

    Vector3 GetRandomLocation()
    {
        var grid = AstarPath.active.data.gridGraph;

        var randomNode = grid.nodes[Random.Range(0, grid.nodes.Length)];

        // Check if random node is walkable
        while (!randomNode.Walkable)
        {
            randomNode = grid.nodes[Random.Range(0, grid.nodes.Length)];
        }

        return (Vector3)randomNode.position;
    }

    void UpdateTargetLocation(Vector3 targetLocation)
    {
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