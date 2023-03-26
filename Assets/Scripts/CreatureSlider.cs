using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureSlider : MonoBehaviour
{
    public Text valueText;
    
    public void OnSliderChanged(float value)
    {
        // Set text to be "Creatures: " + value
        valueText.text = "Creatures: " + value;
    }
}
