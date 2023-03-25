using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    // Vision collider
    public CircleCollider2D visionCollider;


    public float speed = 10;
    public Rigidbody2D rb;
    public float perlinSpeed = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void PickTargetLocation()
    {
        // Picks a location to move to from somewhere within the viewport
        // Get the viewport size
        Vector3 viewportSize = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        
        // Get a random location within the viewport
        Vector3 targetLocationViewport = new Vector3(Random.Range(0, 1), Random.Range(0, 1), 0);
        
    }

    // Update is called once per frame
    void Update()
    {
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
