using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool keyWasPressed;
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !keyWasPressed)
        {
            // Toggle the flag
            keyWasPressed = true;

            // Deactivate or activate objects based on the current level
            Pause();
        }
        else if (!Input.GetKey(KeyCode.L))
        {
            // Reset the flag when the key is released
            keyWasPressed = false;
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
