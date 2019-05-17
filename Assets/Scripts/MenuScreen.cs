using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void GoToStartScreen()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
