using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    // Plant density
    public int numPlants = 0;

    // Number of creatures
    public int numCreatures = 1;

    public bool cannibalism = true;

    // Creature prefab
    public GameObject creaturePrefab;

    // List of 5 plant prefabs
    public GameObject[] plantPrefabs;

    // Persistent
    public Persistent persistent;

    // Start is called before the first frame update
    void Start()
    {
        // Pause the game
        Time.timeScale = 0;
        persistent = GameObject.FindWithTag("Persistent").GetComponent<Persistent>();
        persistent.time = 0;

        // Populate map with plants and creatures
        PopulateMap();
    }

    // Clear all plants, creatures, babies and corpses from the map
    public void ClearMap()
    {
        persistent.ResetStats();

        // Get all GameObjects with tag "Plant"
        GameObject[] plants = GameObject.FindGameObjectsWithTag("Plant");

        // Destroy all plants
        foreach (GameObject plant in plants)
        {
            Destroy(plant);
        }

        // Get all GameObjects with tag "Creature"
        GameObject[] creatures = GameObject.FindGameObjectsWithTag("Creature");

        // Destroy all creatures
        foreach (GameObject creature in creatures)
        {
            Destroy(creature);
        }

        // Get all GameObjects with tag "Baby"
        GameObject[] babies = GameObject.FindGameObjectsWithTag("Baby");

        // Destroy all babies
        foreach (GameObject baby in babies)
        {
            Destroy(baby);
        }

        // Get all GameObjects with tag "Corpse"
        GameObject[] corpses = GameObject.FindGameObjectsWithTag("Corpse");

        // Destroy all corpses
        foreach (GameObject corpse in corpses)
        {
            Destroy(corpse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        persistent.time += Time.deltaTime;

        // Count number of Creatures every 2 seconds
        if (persistent.time % 2 < Time.deltaTime)
        {
            int livingCreatures = GameObject.FindGameObjectsWithTag("Creature").Length;

            // If persistent.time is greater than 60 seconds then set win to true
            if (persistent.time > 60)
            {
                persistent.win = true;
            }

            // If no living creatures then load scene 2 and set win to false in 2 seconds
            if (livingCreatures == 0)
            {
                persistent.win = false;
                SceneManager.LoadScene(2);
            }
        }
    }

    // Populate map with plants and creatures
    public void PopulateMap()
    {
        persistent.initialCreatures = numCreatures;
        persistent.cannibalism = cannibalism;
        persistent.numPlants = numPlants;

        // Spawn plants
        for (int i = 0; i < numPlants; i++)
        {
            // Randomly select one of 5 plant prefabs
            GameObject plantPrefab = plantPrefabs[Random.Range(0, plantPrefabs.Length)];

            Vector3 plantPosition = AddNoise(GetRandomWalkableLocation(), 0.1f);

            // Add Z + 1 to plant position
            plantPosition.z += 1;

            // Instantiate plant prefab at random location
            Instantiate(
                plantPrefab,
                plantPosition,
                Quaternion.identity
            );
        }

        // Spawn creatures
        for (int i = 0; i < numCreatures; i++)
        {
            // Instantiate creature prefab at random location
            Instantiate(
                creaturePrefab,
                AddNoise(GetRandomWalkableLocation(), 0.1f),
                Quaternion.identity
            );
        }
    }

    // Add noise to Vector3 location in x and y
    public static Vector3 AddNoise(Vector3 location, float noise)
    {
        return new Vector3(
            location.x + Random.Range(-noise, noise),
            location.y + Random.Range(-noise, noise),
            location.z
        );
    }

    public static Vector3 GetRandomWalkableLocation()
    {
        var grid = AstarPath.active.data.gridGraph;

        var randomNode = grid.nodes[Random.Range(0, grid.nodes.Length)];

        // Check if random node is walkable
        while (!randomNode.Walkable)
        {
            randomNode = grid.nodes[Random.Range(0, grid.nodes.Length)];
        }

        return (Vector3)randomNode.position;
    }
}