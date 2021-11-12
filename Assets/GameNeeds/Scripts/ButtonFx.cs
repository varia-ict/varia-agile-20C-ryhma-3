using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFx : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip HoverFx;
    public AudioClip clickFx;

    public void HoverSound()
    {
        myFx.PlayOneShot(HoverFx);
    }
    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }

}