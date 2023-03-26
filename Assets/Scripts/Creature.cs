using DefaultNamespace;
using Pathfinding;
using UnityEngine;

public class Creature : MonoBehaviour
{
    // Animator
    public Animator animator;

    // AI Destination Setter
    public AIDestinationSetter aiDestinationSetter;

    // Corpse prefab
    public GameObject corpsePrefab;

    // Hunger level
    public float hunger;

    // Maximum hunger level
    public float maxHunger = 100;

    // Hunger gain per second
    public float hungerGain = 10;

    // Hunger loss from nibbling a plant
    public float nibbleHungerLoss = 10;

    // Target buffer
    public float targetBuffer = 0.2f;

    // Destination object
    private Transform _destination;

    public bool notDead;

    // Idling
    public bool idling = false;

    // Start is called before the first frame update
    void Start()
    {
        notDead = true;

        animator.SetBool("FacingLeft", false);
        _destination = new GameObject().transform;

        // Create transform from random location
        aiDestinationSetter.target = _destination;

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

    public void UpdateTargetLocation(Vector3 targetLocation)
    {
        // Set the target location to a random location
        aiDestinationSetter.target.position = targetLocation;
    }

    // Update is called once per frame
    void Update()
    {
        if (notDead && !idling)
        {
            // // Check if the target location has been reached
            if (Vector3.Distance(transform.position, aiDestinationSetter.target.position) < targetBuffer)
            {
                // If so, pick a new target location
                UpdateTargetLocation(GetRandomLocation());
            }

            // Increase hunger
            hunger += hungerGain * Time.deltaTime;

            // Check if hunger is greater than max hunger set Animator state to Dead is true
            if (hunger > maxHunger)
            {
                animator.SetBool("Dead", true);
            }
        }
    }

    // Nibble an Edible
    public void Nibble(Edible edible)
    {
        // Set animation to Eating
        animator.SetBool("Eating", true);

        // Nibble the edible
        edible.Nibbled();

        // Reduce hunger
        hunger -= nibbleHungerLoss;

        // Nibbled edible
        Debug.Log("Nibbled edible");

        // Set the target location to edible position
        UpdateTargetLocation(edible.transform.position);

        // Idle
        idling = true;

        // Wait for 1 seconds
        Invoke("StopEating", 1);
    }

    // Stop eating
    public void StopEating()
    {
        // Set animation to Eating
        animator.SetBool("Eating", false);

        // Stop idling
        idling = false;
    }

    // Freeze the creature
    public void Kill()
    {
        // Calling kill
        Debug.Log("Kill");


        // Disable aiDestinationSetter
        aiDestinationSetter.enabled = false;

        // Disable AIPath
        GetComponent<AIPath>().enabled = false;

        UpdateTargetLocation(transform.position);
        notDead = false;

        // Print notDead
        Debug.Log("notDead: " + notDead);
    }
}