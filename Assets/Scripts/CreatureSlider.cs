using UnityEngine;
using UnityEngine.UI;

public class CreatureSlider : MonoBehaviour
{
    // Controller
    public Controller controller;
    public Text valueText;

    public void OnSliderChanged(float value)
    {
        // Set text to be "Creatures: " + value
        valueText.text = "Creatures: " + value;

        // Set numCreatures to value
        controller.numCreatures = (int)value;

        // Clear map
        controller.ClearMap();

        // Populate map
        controller.PopulateMap();
    }
}