using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LoadScene : MonoBehaviour
{
    //plays main game scene by taking scenemanegment  system and loadingscene by the  name
    public void PlayGame()
    {
        SceneManager.LoadScene("deni");
    }

    //quits game with debuglog too

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    #region github links
    public void OpenGITHUB()
    {
        Application.OpenURL("https://github.com/varia-ict/varia-agile-20C-ryhma-3");
    }
    public void OpenSaif()
    {
        Application.OpenURL("https://github.com/Reck-Saif");
    }
    public void OpenSamuli()
    {
        Application.OpenURL("https://github.com/samuli404");
    }
    public void OpenDeni()
    {
        Application.OpenURL("https://github.com/MrThelink");
    }
    public void OpenSameer()
    {
        Application.OpenURL("https://github.com/Sameerwaseem21");
    }
    public void OpenNiamat()
    {
        Application.OpenURL("https://github.com/Niamat2222");
    }
    public void OpenZeta()
    {
        Application.OpenURL("https://github.com/zeta404-ops");
    }
    #endregion
    public void LoadCredit()
    {
        SceneManager.LoadScene("Credits");
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}