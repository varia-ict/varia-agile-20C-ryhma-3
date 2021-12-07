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
        currentWeapon = wp;
        currentWeapon.transform.position = equipPosition.position;
        currentWeapon.transform.parent = equipPosition;
  //      currentWeapon.transform.localEulerAngles = new Vector3(1.12f, -0.38f, 2.11f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;

        currentWeapon.transform.Rotate(new Vector3(-6.49f, 191.704f, 1.298f));
        currentWeapon.transform.position = new Vector3(1.1f, -0.6f, 3.1f);
    }
    private void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon = null;
    }
}