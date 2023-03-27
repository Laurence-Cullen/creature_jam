using TMPro;
using UnityEngine;

public class NameInput : MonoBehaviour
{
    // Persistent
    public Persistent persistent;

    // Text mesh pro input field
    public TMP_InputField inputField;

    // Update the player name
    public void UpdatePlayerName(string newName)
    {
        persistent.UpdatePlayerName(inputField.text);
    }
}