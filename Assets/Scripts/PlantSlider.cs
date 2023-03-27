using UnityEngine;

public class PlantSlider : MonoBehaviour
{
    // Controller
    public Controller controller;

    public void OnSliderChanged(int value)
    {
        // Set plant density to value
        controller.numPlants = value;

        // Clear map
        controller.ClearMap();

        // Populate map
        controller.PopulateMap();
    }
}