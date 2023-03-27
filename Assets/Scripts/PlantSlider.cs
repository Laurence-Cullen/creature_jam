using UnityEngine;

public class PlantSlider : MonoBehaviour
{
    // Controller
    public Controller controller;

    public void OnSliderChanged(float value)
    {
        // Set plant density to value
        controller.numPlants = (int)value;

        // Clear map
        controller.ClearMap();

        // Populate map
        controller.PopulateMap();
    }
}