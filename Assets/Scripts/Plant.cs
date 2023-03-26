using DefaultNamespace;
using UnityEngine;

public class Plant : Edible
{
    public SpriteRenderer spriteRenderer;

    // Sprites for different health levels
    public Sprite fullHealthSprite;
    public Sprite slightlyNibbledSprite;
    public Sprite nibbledSprite;
    public Sprite veryNibbledSprite;

    // Dormancy period, in which plant stops regrowing for a time
    public float dormancyPeriod = 10;

    // Dormant
    public bool dormant;

    // Time dormant
    public float timeDormant;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dormant = false;
        timeDormant = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Update sprite based on health
        if (nutrition > 75)
        {
            spriteRenderer.sprite = fullHealthSprite;
        }
        else if (nutrition > 50)
        {
            spriteRenderer.sprite = slightlyNibbledSprite;
        }
        else if (nutrition > 25)
        {
            spriteRenderer.sprite = nibbledSprite;
        }
        else
        {
            spriteRenderer.sprite = veryNibbledSprite;
        }

        // If dormant
        if (dormant)
        {
            // Increment time dormant
            timeDormant += Time.deltaTime;

            // If time dormant greater than dormancy period
            if (timeDormant > dormancyPeriod)
            {
                // Leave dormancy
                dormant = false;
                nutrition = 30;
                timeDormant = 0;
            }
        }
        else
        {
            // Recover nutrition
            RecoverNutrition();
        }
    }

    public new void Nibbled()
    {
        nutrition -= nibbleAmount;
        if (nutrition <= 0)
        {
            dormant = true;
        }
    }

    // Nibbleable 
    public new bool Nibbleable()
    {
        if (dormant)
        {
            return false;
        }

        return nutrition > 0;
    }
}