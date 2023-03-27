using UnityEngine;

public class CannibalismToggle : MonoBehaviour
{
    // Controller
    public Controller controller;
    
    // On toggle
    public void OnToggle(bool value)
    {
        // Print
        Debug.Log("Cannibalism: " + value);

        // Set cannibalism to value
        controller.SetCannibalism(value);
    }
}