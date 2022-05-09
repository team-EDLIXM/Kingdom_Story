using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PMScript : MonoBehaviour
{
    public void Play()
    {
        Time.timeScale = 1.0f;
    }

    public void Mmenu()
    {
        FindObjectOfType<HolderScript>().DestroyThis();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }

    public void Quit() 
    {
        Application.Quit();
    }
}
