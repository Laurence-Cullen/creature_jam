using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;
    public float perlinSpeed = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        
        // Add random movement
        Vector3 vel = rb.velocity;
        float currTime = Time.frameCount * Time.deltaTime;
        
        // Log output the perlin noise values
        Debug.Log(2 * Mathf.PerlinNoise(currTime, 0) - 1);
        Debug.Log(2 * Mathf.PerlinNoise(0, currTime) - 1);
        vel.x = perlinSpeed * (2 * Mathf.PerlinNoise(currTime, 0) - 1);
        vel.y = perlinSpeed * (2 * Mathf.PerlinNoise(0, currTime) - 1);
        
        rb.velocity = vel;
    }
}
