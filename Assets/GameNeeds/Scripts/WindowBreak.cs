using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBreak : MonoBehaviour

{
    public GameObject window;
    public AudioSource windowSfx;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tomato")
        {
            windowSfx.Play();
            Destroy(gameObject);
        }
    }
}
