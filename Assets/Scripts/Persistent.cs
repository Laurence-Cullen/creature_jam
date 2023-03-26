using TMPro;
using UnityEngine;

public class Persistent : MonoBehaviour
{
    // Player name
    public string playerName = "Player";

    // Name card
    public TextMeshProUGUI nameCard;

    // Initial number of creatures
    public int numCreatures = 10;

    // Initial number of plants
    public int numPlants = 10;

    // Cannibalism enabled
    public bool cannibalism = true;

    // Creatures born
    public int creaturesBorn = 0;

    // Creatures eaten
    public int creaturesEaten = 0;

    // Creatures died
    public int creaturesDied = 0;

    // Generations
    public int generations = 1;

    // Awake
    // void Awake()
    // {
    //     // Dont destroy this object
    //     DontDestroyOnLoad(this.gameObject);
    // }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Update the player name
    public void UpdatePlayerName(string newName)
    {
        playerName = newName;

        // Update the text on the TMPro.TextMeshProUGUI component of nameCard
        nameCard.text = playerName;
    }
}