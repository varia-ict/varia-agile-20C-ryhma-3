using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Transform equipPosition;
    public float distance = 10f;
    GameObject currentWeapon;
    GameObject wp;

    bool canGrab;



    // Update is called once per frame
    void Update()
    {
        CheckWeapons();

        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pick up weapon");

                if (currentWeapon != null)
                    Drop();
                Pickup();

            }

        }
        if (currentWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
                Drop();

        }
    }


    private void CheckWeapons()

    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "CanGrab")
            {
                Debug.Log("I can grab it!");
                canGrab = true;
                wp = hit.transform.gameObject;
            }

        }
        else

            canGrab = false;
    }



    private void Pickup()
    {
        Vector3 temp = new Vector3(7.0f, 0, 0);
        currentWeapon = wp;
        currentWeapon.transform.position = temp;
        
        currentWeapon.transform.parent = equipPosition;
        currentWeapon.transform.localEulerAngles = new Vector3(0, 180, 0);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
    }
    private void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon = null;
    }
}