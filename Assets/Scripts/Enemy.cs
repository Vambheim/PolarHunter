using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;  // To restart the game


public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshAgent nav;

    public GameObject gameOverPanel;  

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();

        // Hide the Game Over panel at the start
        gameOverPanel.SetActive(false);

        // Hide the cursor at the start of the game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        nav.destination = playerTransform.position;
    }

    // Called when the enemy touches the player
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverPanel.SetActive(true);

        // Show the mouse cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;  // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1;  // Unpause the game

        // Hide the cursor again when restarting the game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }
}
