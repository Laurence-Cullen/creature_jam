using Pathfinding;
using UnityEngine;

public class Creature : MonoBehaviour
{
    // Random AudioClip 
    public AudioClip[] randomNoises;

    // Animator
    public Animator animator;

    // Persistent
    public Persistent persistent;

    // AI Destination Setter
    public AIDestinationSetter aiDestinationSetter;

    // Corpse prefab
    public GameObject corpsePrefab;

    // Generation
    public int generation = 1;

    // Hunger level
    public float hunger;

    // Maximum hunger level
    public float maxHunger = 100;

    // Hunger gain per second
    public float hungerGain = 10;

    // Hunger loss from nibbling a plant
    public float nibbleHungerLoss = 10;

    // Reproduction hunger threshold
    public float reproductionHungerThreshold = 50;
    public float reproductionHungerCost = 30;

    // Target buffer
    public float targetBuffer = 0.2f;

    // Destination object
    private Transform _destination;

    public bool notDead;

    // Idling
    private bool _idling;

    // Incubation period, time before creature can reproduce
    public float incubationPeriod = 15;

    // Time since last reproduction
    private float _timeSinceLastReproduction;

    // Reproduction max distance
    public float reproductionMaxDistance = 0.5f;

    // Romantic partner
    public Creature partner;

    // Baby prefab
    public GameObject babyPrefab;

    // Heart prefab
    public GameObject heartPrefab;

    private static readonly int Eating = Animator.StringToHash("Eating");

    private static readonly int Dead = Animator.StringToHash("Dead");

    // private static readonly int FacingLeft = Animator.StringToHash("FacingLeft");
    private static readonly int Idling = Animator.StringToHash("Idling");

    private GameObject _destinationObject;

    // Cannibalistic
    public bool cannibalistic = true;

    // Start is called before the first frame update
    void Start()
    {
        // Find persistent
        persistent = GameObject.FindWithTag("Persistent").GetComponent<Persistent>();

        persistent.numCreatures++;

        // Randomise hunger between 0 and 50
        hunger = Random.Range(0, 50);

        notDead = true;
        _destinationObject = new GameObject();
        _destination = _destinationObject.transform;

        // Create transform from random location
        aiDestinationSetter.target = _destination;

        UpdateTargetLocation(Controller.GetRandomWalkableLocation());

        // Between every 5 and 10 seconds, play a random noise
        InvokeRepeating(nameof(PlayRandomNoise), Random.Range(5, 10), Random.Range(5, 10));
    }


    // Play a random noise
    void PlayRandomNoise()
    {
        // Get a random AudioClip from the list
        AudioClip randomNoise = randomNoises[Random.Range(0, randomNoises.Length)];

        // Play the random AudioClip
        AudioSource.PlayClipAtPoint(randomNoise, transform.position);
    }


    public void UpdateTargetLocation(Vector3 targetLocation)
    {
        // Set the target location to a random location
        aiDestinationSetter.target.position = targetLocation;
    }

    // Update is called once per frame
    void Update()
    {
        if (notDead && !_idling)
        {
            // // Check if the target location has been reached
            if (Vector2.Distance(transform.position, aiDestinationSetter.target.position) < targetBuffer)
            {
                // If so, pick a new target location
                UpdateTargetLocation(Controller.GetRandomWalkableLocation());
            }
        }

        // Increase hunger
        hunger += hungerGain * Time.deltaTime;

        // Check if hunger is greater than max hunger set Animator state to Dead is true
        if (hunger > maxHunger)
        {
            animator.SetBool(Dead, true);
        }

        // If we have a partner move check if we are close enough to reproduce
        if (partner != null)
        {
            // Check if we are close enough to reproduce
            if (DistanceToCreature(partner) < reproductionMaxDistance)
            {
                // If so, reproduce
                Reproduce(partner);
            }
        }

        _timeSinceLastReproduction += Time.deltaTime;
    }

    // Nibble plant
    public void NibblePlant(Plant plant)
    {
        plant.Nibbled();
        Nibble(plant);
    }

    // Nibble corpse
    public void NibbleCorpse(Corpse corpse)
    {
        corpse.Nibbled();
        Nibble(corpse);
    }

    // Nibble a subclass of Edible
    public void Nibble(Edible edible)
    {
        // Set animation to Eating
        animator.SetBool(Eating, true);

        // Reduce hunger
        hunger -= nibbleHungerLoss;

        // Set the target location to edible position
        UpdateTargetLocation(edible.transform.position);

        // Idle
        _idling = true;

        // Wait for 1 seconds
        Invoke(nameof(StopEating), 1);
    }

    // Stop eating
    public void StopEating()
    {
        // Set animation to Eating
        animator.SetBool(Eating, false);

        // Stop idling
        _idling = false;
    }

    // Accept a proposition
    public void AcceptProposition(Creature otherCreature)
    {
        HeartEmote();

        _idling = true;
        // Set the target location to other creature position
        UpdateTargetLocation(otherCreature.transform.position);
        partner = otherCreature;
    }

    // Heart emote
    public void HeartEmote()
    {
        // Create heart prefab above creature and destroy after 1.5 seconds
        var heart = Instantiate(
            heartPrefab,
            transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity
        );
        Destroy(heart, 1.5f);
    }

    // Big heart emote
    public void BigHeartEmote()
    {
        // Create heart prefab above creature and destroy after 1.5 seconds
        var heart = Instantiate(
            heartPrefab,
            transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity
        );
        heart.transform.localScale = new Vector3(2, 2, 2);
        Destroy(heart, 1.5f);
    }

    // Proposition another creature
    public void Proposition(Creature otherCreature)
    {
        _idling = true;

        // Heart emote
        HeartEmote();

        // Set the target location to other creature position
        UpdateTargetLocation(otherCreature.transform.position);

        // Check if other creature is ready to reproduce
        if (otherCreature.ReadyToReproduce())
        {
            // Accept proposition
            otherCreature.AcceptProposition(this);
            partner = otherCreature;
        }

        // Wait for 1 seconds
        Invoke(nameof(StopPropositioning), 1);
    }

    // Check distance between two creatures
    public float DistanceToCreature(Creature otherCreature)
    {
        // Return distance between other creature and this creature
        return Vector3.Distance(transform.position, otherCreature.transform.position);
    }

    // Stop propositioning
    public void StopPropositioning()
    {
        // If we have a partner continue to idle
        if (partner != null)
        {
            _idling = true;
        }
        else
        {
            // Stop idling
            _idling = false;
        }
    }

    // Check if ready to reproduce
    public bool ReadyToReproduce()
    {
        // If not dead
        if (notDead)
        {
            // Check if hunger is greater than reproduction hunger threshold
            if (hunger < reproductionHungerThreshold)
            {
                // Check if incubation period has passed
                if (_timeSinceLastReproduction > incubationPeriod)
                {
                    // Return true
                    return true;
                }
            }
        }

        // Return false
        return false;
    }

    // Reproduce
    public void Reproduce(Creature otherCreature)
    {
        // Big heart emote
        BigHeartEmote();

        // Set animation to idling
        animator.SetBool(Idling, true);

        // Set the target location to position of partner
        UpdateTargetLocation(otherCreature.transform.position);

        partner = null;
        otherCreature.partner = null;

        // Idle
        _idling = true;
        otherCreature._idling = true;

        // Add hunger cost
        hunger += reproductionHungerCost;

        // Reset time since last reproduction
        _timeSinceLastReproduction = 0;
        otherCreature._timeSinceLastReproduction = 0;

        // Instantiate baby
        GameObject baby = Instantiate(babyPrefab, transform.position, Quaternion.identity);

        // Set baby's generation to this creature's generation + 1
        baby.GetComponent<Baby>().generation = generation + 1;

        // Set persistent's generation to the maximum of the current generation and the baby's generation

        persistent.generations = Mathf.Max(persistent.generations, baby.GetComponent<Baby>().generation);

        persistent.creaturesBorn++;

        // Set baby cannibalism
        baby.GetComponent<Baby>().cannibalistic = cannibalistic;

        // Wait for 1 seconds
        Invoke(nameof(StopReproducing), 1);
    }

    // Stop reproducing
    public void StopReproducing()
    {
        // Set animation to not Reproducing
        animator.SetBool(Idling, false);

        // Stop idling
        _idling = false;
    }

    public void Kill()
    {
        Destroy(_destinationObject);

        persistent.creaturesDied++;

        // Disable aiDestinationSetter
        aiDestinationSetter.enabled = false;

        // Disable AIPath
        GetComponent<AIPath>().enabled = false;

        UpdateTargetLocation(transform.position);
        notDead = false;
    }

    // IsIdle
    public bool IsIdle()
    {
        return _idling;
    }
}