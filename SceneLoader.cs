using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private GameObject LoseScreenScene;
    private GameObject WinScreenScene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    private void Awake()
    {
        LoseScreenScene = GameObject.FindGameObjectWithTag("EndGame");
        WinScreenScene = GameObject.FindGameObjectWithTag("WinGame");

        if (LoseScreenScene == null)
        {
            Debug.LogError("LoseScreenScene not found. Make sure an object with the tag 'EndGame' exists in the scene.");    
        }
        if (WinScreenScene == null)
        {
            Debug.LogError("WinScreenScene not found. Make sure an object with the tag 'WinGame' exists in the scene.");
        }
    }


    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is within the range of added scenes
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes to load!"); // Optional: Handle this case
        }
        Time.timeScale = 1.0f;
    }

    public void LoseScreen()
    {
        if (LoseScreenScene != null)
        {
            // Debug.Log("Triggered");
            LoseScreenScene.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("LoseScreenScene is null.");
        }
    }

    public void WinScreen()
    {
        if (WinScreenScene != null)
        {
            WinScreenScene.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("WinScreenScene is null.");
        }
    }


    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.name);

        Time.timeScale = 1;
    }

    public void LoadMenuScene()
    {
        // Load the scene named "Menu"
        SceneManager.LoadScene(0    );
        Time.timeScale = 1;
    }
}
