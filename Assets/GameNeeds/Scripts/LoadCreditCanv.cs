using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCreditCanv : MonoBehaviour
{
    public GameObject panel;

    public void OpenCreditPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }

    public void CloseCreditPanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}
