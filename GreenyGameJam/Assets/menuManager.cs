using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject main;
    public GameObject options;
    public GameObject credits;

    public GameObject pauseScreen;
    public void Exit()
    {
        Application.Quit();
    }

    public void openPauseScreen()
    {
        if(pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);
        }
        else
        {
            pauseScreen.SetActive(false);
        }
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void CloseAllScenes()
    {
        main.SetActive(false);
        options.SetActive(false);
        credits.SetActive(false);
    }

    public void OpenMain()
    {
        CloseAllScenes();
        main.SetActive(true);
    }
    public void OpenOptions()
    {
        CloseAllScenes();
        options.SetActive(true);
    }
    public void OpenCredits()
    {
        CloseAllScenes();
        credits.SetActive(true);
    }
}
