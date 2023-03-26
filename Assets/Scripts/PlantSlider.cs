using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSlider : MonoBehaviour
{
    public Text valueText;
    
    public void OnSliderChanged(float value)
    {
        // Set text to be "Plants: " + value
        valueText.text = "Plants: " + value;
    }
}
