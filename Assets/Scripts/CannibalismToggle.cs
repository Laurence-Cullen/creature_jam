using UnityEngine;

public class CaniballismToggle : MonoBehaviour
{
    // Controller
    public Controller controller;

    // On toggle
    public void OnToggle(bool value)
    {
        // Set cannibalism to value
        controller.cannibalism = value;
    }
}