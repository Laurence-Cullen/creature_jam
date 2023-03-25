using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    // Vision collider
    public CircleCollider2D visionCollider;


    public float speed = 10;
    public Rigidbody2D rb;

    public float perlinSpeed = 0.001f;
    private Vector2 TargetLocation;

    // Start is called before the first frame update
    void Start()
    {
        // Set the target location to a random location
        TargetLocation = GetRandomLocation();
    }

    Vector2 GetRandomLocation()
    {
        // Picks a location to move to from somewhere within the viewport
        Vector3 targetLocationViewport = new Vector3(Random.Range(0, 1), Random.Range(0, 1), 0);
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
        
        Vector3 pos = transform.position;

        // Add random movement
        Vector3 vel = rb.velocity;
        float currTime = Time.frameCount * Time.deltaTime;

        // Log output the perlin noise values
        // Debug.Log(2 * Mathf.PerlinNoise(currTime, 0) - 1);
        // Debug.Log(2 * Mathf.PerlinNoise(0, currTime) - 1);
        vel.x = perlinSpeed * (2 * Mathf.PerlinNoise(currTime, 0) - 1);
        vel.y = perlinSpeed * (2 * Mathf.PerlinNoise(0, currTime) - 1);

        rb.velocity = vel;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Print to console the name of the other collider
        Debug.Log(other.gameObject.name);

        // // If the other collider is a plant
        // if (other.gameObject.CompareTag("Plant"))
        // {
        //     // Get the plant component
        //     Plant plant = other.gameObject.GetComponent<Plant>();
        //     // Nibble the plant
        //     plant.Nibbled();
        // }
    }
}