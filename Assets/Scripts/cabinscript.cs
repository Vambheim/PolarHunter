using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // For UI Elements
using UnityEngine.SceneManagement; // For ending the game

public class Cabin : MonoBehaviour
{
    public GameObject enterCabinButton;  // We will find the button in the Start method
    private bool isPlayerNearCabin = false;  // Track if player is near the cabin

    void Start()
    {
        // Find the button by name
        enterCabinButton = GameObject.Find("EnterCabinButton");

        // Check if the button was found
        if (enterCabinButton == null)
        {
            Debug.LogError("EnterCabinButton not found! Please check the name in the Hierarchy.");
        }
        else
        {
            // Hide it at the start (it should already be inactive in the Editor)
            enterCabinButton.SetActive(false);  
        }
    }

    // Detect if the player is near the cabin
  void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        isPlayerNearCabin = true;
        enterCabinButton.SetActive(true); // Show the button when player is near
        Cursor.lockState = CursorLockMode.None; // Show the cursor
        Cursor.visible = true; // Make the cursor visible
    }
}

    // Detect when the player leaves the cabin trigger zone
   void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        isPlayerNearCabin = false;
        enterCabinButton.SetActive(false); // Hide the button when player leaves
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor again
        Cursor.visible = false; // Hide the cursor
    }
}


    // This function should be connected to the "Enter Cabin" button
public void EnterCabin()
{
    Debug.Log("EnterCabin button clicked."); // Confirm button click
    if (isPlayerNearCabin)
    {
        // End the game (you can trigger a win state, show a message, or load another scene)
        Debug.Log("Game Won! Player entered the cabin.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the scene for now
    }
}


}
