using UnityEngine;

public class Plant : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public float nibbleAmount = 10; // how much health is lost when nibbled
    public SpriteRenderer spriteRenderer;

    // Sprite for when at full health
    public Sprite fullHealthSprite;

    // Mid health sprite
    public Sprite midHealthSprite;

    // Low health sprite
    public Sprite nearlyDeadSprite;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if health is greater than 66% of max health
        if (health > maxHealth * 0.66f)
        {
            // set the sprite to the full health sprite
            spriteRenderer.sprite = fullHealthSprite;
        }
        // if health is greater than 33% of max health
        else if (health > maxHealth * 0.33f)
        {
            // set the sprite to the mid health sprite
            spriteRenderer.sprite = midHealthSprite;
        }
        // if health is less than or equal to 33% of max health
        else
        {
            // set the sprite to the low health sprite
            spriteRenderer.sprite = nearlyDeadSprite;
        }
    }

    // called when the plant is nibbled
    public void Nibble()
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