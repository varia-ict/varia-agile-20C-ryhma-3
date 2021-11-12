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
          Debug.Log("Button clicked");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void OpenUrl()
    {
        Application.OpenURL("https://www.instagram.com/zhinar_0%22");
    }
    public void LoadCredit()
    {
        SceneManager.LoadScene("Credits");
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("FTW MAIN MENU 1");
    }
}