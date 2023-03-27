using UnityEngine;

public class MainMusic : MonoBehaviour
{
    // Music audio clips
    public AudioClip music1;
    public AudioClip music2;

    // Start is called before the first frame update
    void Start()
    {
        // Select a random music clip and play it, when it ends play the other. Cycle between the two.
        if (Random.Range(0, 2) == 0)
        {
            GetComponent<AudioSource>().clip = music1;
            GetComponent<AudioSource>().Play();
            Invoke("PlayMusic2", music1.length);
        }
        else
        {
            GetComponent<AudioSource>().clip = music2;
            GetComponent<AudioSource>().Play();
            Invoke("PlayMusic1", music2.length);
        }
    }

    // Play music 1
    void PlayMusic1()
    {
        GetComponent<AudioSource>().clip = music1;
        GetComponent<AudioSource>().Play();
        Invoke("PlayMusic2", music1.length);
    }

    // Play music 2
    void PlayMusic2()
    {
        GetComponent<AudioSource>().clip = music2;
        GetComponent<AudioSource>().Play();
        Invoke("PlayMusic1", music2.length);
    }

    // Update is called once per frame
    void Update()
    {
    }
}