using UnityEngine;
using UnityEngine.UI;

public class Persistent : MonoBehaviour
{
    // Player name
    public string playerName = "Player";

    // Name card Legacy text component
    public Text nameCard;

    public float time = 0;

    // Total number of creatures
    public int numCreatures = 10;

    // Initial number of creatures
    public int initialCreatures = 10;

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
    void Awake()
    {
        // Dont destroy this object
        DontDestroyOnLoad(this.gameObject);
    }

    // Update

    // Reset simulation stats to 0
    public void ResetStats()
    {
        // Reset stats
        numCreatures = 0;
        initialCreatures = 0;
        creaturesBorn = 0;
        creaturesEaten = 0;
        creaturesDied = 0;
        generations = 1;
        numPlants = 0;
        time = 0;
    }


    // Update the player name
    public void UpdatePlayerName(string newName)
    {
        // Print
        Debug.Log("Updating player name to: " + newName);

        playerName = newName;

        // Update the text on the Text component of the name card
        nameCard.text = playerName;
    }
}