using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    public GameObject crosshair;

    public GameObject player;
    public Rigidbody playerbody;

    private FirstPersonMovement playerIsGrounded;

    public AudioSource walkAudioSource;
    public AudioClip walkSound;

    public GameObject musicSource;

    void Start()
    {
        isPaused = false;

        pauseMenu.SetActive(false);

        walkAudioSource = player.GetComponent<AudioSource>();

        playerbody = player.GetComponent<Rigidbody>();
        playerIsGrounded = player.GetComponent<FirstPersonMovement>();
    }

    private void Awake()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }
        }        
    }

    private void PauseGame()
    {
        crosshair.SetActive(false);
        isPaused = true;
        AudioListener.pause = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        walkAudioSource.Stop();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        crosshair.SetActive(true);
        isPaused = false;
        AudioListener.pause = false;
        walkAudioSource.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
        walkAudioSource.Play();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("Menu");
}

    public void QuitGame()
    {
        Application.Quit();
    }
}
