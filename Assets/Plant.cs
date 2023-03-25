using UnityEngine;

public class Plant : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;
    public float nibbleAmount = 10; // how much health is lost when nibbled
    public SpriteRenderer spriteRenderer;

    // Sprite for when at full health
    public Sprite fullHealthSprite;

    // Low health sprite
    public Sprite nibbledSprite;

    // Health recovery rate per second
    public float healthRecoveryRate = 5;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if health is less than or equal to 50
        if (health <= 50)
        {
            // set the sprite to the nibbled sprite
            spriteRenderer.sprite = nibbledSprite;
        }
        else
        {
            // set the sprite to the full health sprite
            spriteRenderer.sprite = fullHealthSprite;
        }

        // recover health over time if health is less than max health
        if (health < maxHealth)
        {
            health += healthRecoveryRate * Time.deltaTime;
        }
    }

    // called when the plant is nibbled
    public void Nibbled()
    {
        // reduce health by the nibble amount
        health -= nibbleAmount;

        // if health is less than or equal to zero
        if (health <= 0)
        {
            // destroy the plant
            Destroy(gameObject);
        }
    }
}