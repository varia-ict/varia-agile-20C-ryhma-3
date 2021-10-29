using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public GameObject myWeapon;
    public GameObject groundGun;

    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject.tag == "Player")
        {
            myWeapon.SetActive(true);
            groundGun.SetActive(false);
        }
        
    }
}
