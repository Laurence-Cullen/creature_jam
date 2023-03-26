using UnityEngine;

public class CreatureSlider : MonoBehaviour
{
    // Controller
    public Controller controller;

    public void OnSliderChanged(float value)
    {
        // Set numCreatures to value
        controller.numCreatures = (int)value;

        // Clear map
        controller.ClearMap();

        // Populate map
        controller.PopulateMap();
    }
}