using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    // Start the game on click
    public void OnClick()
    {
        // Set game timescale to 0
        Time.timeScale = 0;
    }
}
