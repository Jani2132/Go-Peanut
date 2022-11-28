using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResetGame : MonoBehaviour
{
    public void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
            }
        }
    }
}
