using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenScript : MonoBehaviour
{
    public GameObject endScreenScene;
    public AudioSource yaaySFX;
    
    public void EndScreen()
    {
        endScreenScene.SetActive(true);
        yaaySFX.Play();
    }

    public void QuitGame()
    {
        Debug.Log("Quit the game.");
        Application.Quit();
    }
}
