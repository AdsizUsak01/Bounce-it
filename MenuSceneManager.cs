using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    public GameObject PartScene;

    public void ActivatePartScene()
    {
        PartScene.SetActive(true);
    }

    public void DeactivatePartScene()
    {
        PartScene.SetActive(false);
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

    public void LoadPart1()
    {
        SceneManager.LoadScene("Part1");
        Time.timeScale = 1.0f;
    }

    public void LoadPart2()
    {
        SceneManager.LoadScene("Part2");
        Time.timeScale = 1.0f;
    }

    public void LoadPart3()
    {
        SceneManager.LoadScene("Part3");
        Time.timeScale = 1.0f;
    }

    public void LoadPart4()
    {
        SceneManager.LoadScene("Part4");
        Time.timeScale = 1.0f;
    }

    public void LoadPart5()
    {
        SceneManager.LoadScene("Part5");
        Time.timeScale = 1.0f;
    }

    public void LoadPart6()
    {
        SceneManager.LoadScene("Part6");
        Time.timeScale = 1.0f;
    }

    public void LoadPart7()
    {
        SceneManager.LoadScene("Part7");
        Time.timeScale = 1.0f;
    }

    public void LoadPart8()
    {
        SceneManager.LoadScene("Part8");
        Time.timeScale = 1.0f;
    }

    public void LoadPart9()
    {
        SceneManager.LoadScene("Part9");
        Time.timeScale = 1.0f;
    }

    public void LoadPart10()
    {
        SceneManager.LoadScene("Part10");
        Time.timeScale = 1.0f;
    }
}
