using UnityEngine;

public class Controller : MonoBehaviour
{
    // Plant multiplier
    public float plantMultiplier = 5;

    // Plant density
    public float plantDensity = 0;

    // Number of creatures
    public int numCreatures = 0;

    // Creature prefab
    public GameObject creaturePrefab;

    // List of 5 plant prefabs
    public GameObject[] plantPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // Pause the game
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Clear all plants, creatures, babies and corpses from the map
    public void ClearMap()
    {
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

    // Populate map with plants and creatures
    public void PopulateMap()
    {
        int numPlants = (int)(plantDensity * plantMultiplier);

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