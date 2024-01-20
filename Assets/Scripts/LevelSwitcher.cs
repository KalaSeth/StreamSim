using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    public static LevelSwitcher instance;

    public void GotoMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Chawl()
    {
        SceneManager.LoadScene(2);
    }

    public void StreamPaused()
    {
        Time.timeScale = 0;
    }

    public void StreamResumed()
    {
        Time.timeScale = 1;
    }

    public void ExitSim()
    {
        Application.Quit();
    }
}
