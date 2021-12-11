using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloadingandammo : MonoBehaviour
{
    public GameObject tomato;
    //´this is telling that hw much ammo we need o put like max out one
    public int ammoToReload = 6;
    private int currentAmmo = 0;
    // from this i can set reload time how much we want
    public float timeToreload = 5f;
    public int ammo;
    public bool isFiring;
    public Text ammoDisplay;
    public AudioSource shootSfx;

    // Start is called before the first frame update
    void Start()
    {
        // when the gun is picked up it will make sure to fill ammo
        currentAmmo = ammoToReload;
    }

    // Update is called once per frame
    void Update(){
       
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            
             Reload();
        
        }

        ammoDisplay.text = ammo.ToString();
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            Shoot();
        }
        else { isFiring = true; }

    }

    void Shoot()
    {
       
            Instantiate(tomato, transform.position, transform.rotation);
        tomato.transform.position = transform.position + transform.forward;
        isFiring = true;
        ammo--;
        isFiring = false;
        shootSfx.Play();
        isFiring = false;
    }    

    void Reload ()
       
    {
        if (ammo <= 0)
        {
             ammo += ammoToReload;
        }
         
    }

}

