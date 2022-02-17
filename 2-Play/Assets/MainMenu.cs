using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool ready1;
    private bool ready2;

    void Start()
    {
        Time.timeScale = 1;
        this.ResetReady();
    }

    public void PlayGame(int gameScene)
    {
        if(ready1 && ready2)
            SceneManager.LoadScene(gameScene);
        else return;
    }

    public void ChangeScene(int gameScene)
    {
        SceneManager.LoadScene(gameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeReady1()
    {
        ready1 = true;
    }

    public void ChangeReady2()
    {
        ready2 = true;
    }

    public void ResetReady()
    {
        ready1 = false;
        ready2 = false;
    }
}
