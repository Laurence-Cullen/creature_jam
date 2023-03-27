using UnityEngine;

public class Corpse : Edible
{
    // Persistent
    public Persistent persistent;

    // Start is called before the first frame update
    void Start()
    {
        persistent = GameObject.Find("Persistent").GetComponent<Persistent>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // On destroy
    void OnDestroy()
    {
        // Increment creatures eaten
        persistent.creaturesEaten++;
    }
}