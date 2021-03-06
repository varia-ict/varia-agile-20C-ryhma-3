
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    //Made by Zeta404

    public AudioSource openAudio;
    public Transform PlayerCamera;
    // max distance to open door can be changed in inspector
    public float MaxDistance = 1;

    private bool opened = false;
    private Animator anim;



    void Update()
    {
        //player press F on the Keyboard calls pressed function which excutes right code for our function
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pressed();
        }
    }

    void Pressed()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {

            // if raycast hits, then it checks if it hit an object with the tag Door.
            if (doorhit.transform.tag == "Door")
            {

                //This line will get the Animator from  Parent of the door that was hit by the raycast.
                anim = doorhit.transform.GetComponentInParent<Animator>();

                
                //set the bool the opposite of what it is.
                opened = !opened;
                //plays audio when pressed 
                openAudio.Play();

                // set the bool true so it will play the animation.
                anim.SetBool("Opened", !opened);
                //plays audio when pressed 

                
            }
        }
    }
}
