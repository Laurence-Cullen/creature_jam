using UnityEngine;

public class Baby : MonoBehaviour
{
    // Maturity sound
    public AudioClip maturitySound;

    // Canibalism
    public bool cannibalistic = false;

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
        // Play maturity sound
        var position = transform.position;

        AudioSource.PlayClipAtPoint(maturitySound, position);

        // Instantiate adult
        GameObject adult = Instantiate(adultPrefab, position, Quaternion.identity);

        // Set generation
        adult.GetComponent<Creature>().generation = generation;

        // Set cannibalism
        adult.GetComponent<Creature>().cannibalistic = cannibalistic;

        // Destroy baby
        Destroy(gameObject);
    }
}