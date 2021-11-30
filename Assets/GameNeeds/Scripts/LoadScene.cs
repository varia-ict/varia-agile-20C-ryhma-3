using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LoadScene : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("deni");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void OpenGITHUB()
    {
        Application.OpenURL("https://github.com/varia-ict/varia-agile-20C-ryhma-3");
    }
    public void LoadCredit()
    {
        SceneManager.LoadScene("Credits");
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}