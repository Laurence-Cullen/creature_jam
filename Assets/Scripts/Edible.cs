using UnityEngine;

namespace DefaultNamespace
{
    public class Edible : MonoBehaviour
    {
        // Set nutrition value
        public float nutrition;

        // Max nutrition value
        public float maxNutrition = 100;

        // Recovery rate
        public float recoveryRate;

        // Nibble amount
        public float nibbleAmount = 10;

        // Create constructor
        public Edible()
        {
            nutrition = maxNutrition;
        }

        void Start()
        {
            nutrition = maxNutrition;
        }


        // Update
        void Update()
        {
            RecoverNutrition();
        }

        // Nibbled
        public void Nibbled()
        {
            nutrition -= nibbleAmount;
            if (nutrition <= 0)
            {
                Destroy(gameObject);
            }
        }

        // Recover nutrition
        public void RecoverNutrition()
        {
            if (nutrition < maxNutrition)
            {
                nutrition += recoveryRate * Time.deltaTime;
            }
        }

        // Nibbleable 
        public bool Nibbleable()
        {
            return nutrition > 0;
        }
    }
}