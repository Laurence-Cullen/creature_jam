using UnityEngine;

public class Baby : MonoBehaviour
{
    // Age of baby
    private float _age;

    // Age of maturity
    public float maturityAge = 20;

    // Adult prefab
    public GameObject adultPrefab;

    // Generation
    public int generation = 1;

    // Start is called before the first frame update
    void Start()
    {
        _age = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Increment age
        _age += Time.deltaTime;

        // If age greater than maturity age then grow into adult
        if (_age > maturityAge)
        {
            // Grow into adult
            GrowIntoAdult();
        }
    }

    // Grow into adult
    void GrowIntoAdult()
    {
        // Instantiate adult
        GameObject adult = Instantiate(adultPrefab, transform.position, Quaternion.identity);

        // Set generation
        adult.GetComponent<Creature>().generation = generation;

        // Destroy baby
        Destroy(gameObject);
    }
}