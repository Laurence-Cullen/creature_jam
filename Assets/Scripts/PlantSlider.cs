using UnityEngine;
using UnityEngine.UI;

public class PlantSlider : MonoBehaviour
{
    // Controller
    public Controller controller;

    public Text valueText;

    public void OnSliderChanged(float value)
    {
        // Set text to be "Plants: " + value
        valueText.text = "Plants: " + value;

        // Set plant density to value
        controller.plantDensity = value;

        // Clear map
        controller.ClearMap();

        // Populate map
        controller.PopulateMap();
    }
}