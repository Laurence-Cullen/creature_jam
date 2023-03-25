using UnityEngine;

public class Plant : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;
    public float nibbleAmount = 25; // how much health is lost when nibbled
    public SpriteRenderer spriteRenderer;

    // Sprites for different health levels
    public Sprite fullHealthSprite;
    public Sprite slightlyNibbledSprite;
    public Sprite nibbledSprite;
    public Sprite veryNibbledSprite;

    // Health recovery rate per second
    public float healthRecoveryRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update sprite based on health
        if (health > 75)
        {
            spriteRenderer.sprite = fullHealthSprite;
        }
        else if (health > 50)
        {
            spriteRenderer.sprite = slightlyNibbledSprite;
        }
        else if (health > 25)
        {
            spriteRenderer.sprite = nibbledSprite;
        }
        else
        {
            spriteRenderer.sprite = veryNibbledSprite;
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