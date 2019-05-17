using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCont : MonoBehaviour
{
    public GameObject Camera;
    public PlayerMovement Player;
    public GameObject pauseScreen;
    
    void Update()
    {
        //Locking and unlocking cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseScreen.activeSelf) {
                Cursor.lockState = CursorLockMode.None;
                Camera.GetComponent<PlayerCamera>().CameraDisabled = true;
                pauseScreen.SetActive(true);
                Time.timeScale = 0.01f;

            }
            else {
                Cursor.lockState = CursorLockMode.Locked;
                Camera.GetComponent<PlayerCamera>().CameraDisabled = false;
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (Player.health <= 0)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Camera.GetComponent<PlayerCamera>().CameraDisabled = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToHome()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
