using UnityEngine;

public class Boundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Called when colliding
    void OnCollisionEnter2D(Collision2D other)
    {
        // Print to console the name of the other collider
        // Debug.Log("Boundary collision: " + other.gameObject.name);
    }
}