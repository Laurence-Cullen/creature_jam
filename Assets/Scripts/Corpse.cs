using UnityEngine;

public class Corpse : Edible
{
    // Persistent
    public Persistent persistent;

    // A list of Sprites after being eaten different amounts

    // Not eaten
    public Sprite notEaten;

    // Slightly eaten
    public Sprite slightlyEaten;

    // Moderately eaten
    public Sprite moderatelyEaten;

    // Completely eaten
    public Sprite completelyEaten;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        persistent = GameObject.Find("Persistent").GetComponent<Persistent>();
    }

    // Update is called once per frame
    void Update()
    {
        // If nutrition is between 75 and 100 use notEaten sprite
        if (nutrition is >= 75 and <= 100)
        {
            _spriteRenderer.sprite = notEaten;
        }
        // Else if nutrition is between 50 and 75 use slightlyEaten sprite
        else if (nutrition is >= 50 and <= 75)
        {
            _spriteRenderer.sprite = slightlyEaten;
        }
        // Else if nutrition is between 25 and 50 use moderatelyEaten sprite
        else if (nutrition is >= 25 and <= 50)
        {
            _spriteRenderer.sprite = moderatelyEaten;
        }
        // Else if nutrition is less than 25 use completelyEaten sprite
        else if (nutrition < 25)
        {
            _spriteRenderer.sprite = completelyEaten;
        }
    }

    // On destroy
    void OnDestroy()
    {
        // Increment creatures eaten
        persistent.creaturesEaten++;
    }
}