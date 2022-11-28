using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject musicSource;

    public void PlayGame ()
    {
        SceneManager.LoadScene("Game");
        musicSource.SetActive(false); 
    }

    public void QuitGame ()
    {
        Debug.Log("Kiléptél!");
        Application.Quit();
    }
}
