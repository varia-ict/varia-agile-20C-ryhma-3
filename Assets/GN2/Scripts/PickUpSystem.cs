using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    public Reloadingandammo gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickUpRange, pickUpTime;
    public float dropForwardForce, dropUpwardForce;

    public GameObject theGun;

    public bool equipped;
    public static bool slotFull;

    public GameObject canvasObject;

    public AudioSource gunDropSfx;
    public AudioSource gunPickupSfx;
    private void Start()
    {
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
            
        }
        if (equipped)
        {
            slotFull = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
           
        }
    }
    private void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) 
        {
            PickUp();
            canvasObject.SetActive(true);
            gunPickupSfx.Play();
        }
        


        //Drop if equipped and "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
            canvasObject.SetActive(false);
            gunDropSfx.Play();
        }
     



    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to the equippedPosition
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigidbody Kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Enable script
        gunScript.enabled = true;
        


    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        theGun.transform.position = new Vector3(-9, 22, 475);
    

        //Disable script
        gunScript.enabled = false;
        


    }
}
