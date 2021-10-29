using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
    {

        public Transform cameraTransform;
        public KeyCode pickupKey = KeyCode.F;
        public KeyCode dropKey = KeyCode.G;
        string weaponTag = "Weapon";

        public List<GameObject> weapons;
        public int maxWeapons = 2;

        // this variable represent the weapon you carry in your hand 
        public GameObject currentWeapon;

        // this variable represent your hand which you set as the parent of your currentWeapon
        public Transform hand;

        // Insert a gameobject which you drop inside your player gameobject and position it where you want to drop items from
        // to avoid dropping items inside your player
        public Transform dropPoint;

        void Update()
        {

            // SELECT WEAPONS
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectWeapon(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectWeapon(1);
            }

            // PICKUP WEAPONS
            RaycastHit hit;
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag(weaponTag) && Input.GetKeyDown(pickupKey) && weapons.Count < maxWeapons)
                {

                    // save the weapon                
                    weapons.Add(hit.collider.gameObject);

                    // hides the weapon because it's now in our 'inventory'
                    hit.collider.gameObject.SetActive(false);

                    // now we can positioning the weapon at many other places.
                    // but for this demonstration where we just want to show a weapon
                    // in our hand at some point we do it now.
                    hit.transform.parent = hand;
                    hit.transform.position = Vector3.zero;
                }
            }

            // DROP WEAPONS
            // So let's say you wanted to add a feature where you wanted to drop the weapon you carry in your hand
            if (Input.GetKeyDown(dropKey) && currentWeapon != null)
            {

                // First ensure we remove our hand as parent for the weapon
                currentWeapon.transform.parent = null;

                // Move the weapon to the drop position
                currentWeapon.transform.position = dropPoint.position;

                // Remove it from our 'inventory'            
                var weaponInstanceId = currentWeapon.GetInstanceID();
                for (int i = 0; i < weapons.Count; i++)
                {
                    if (weapons[i].GetInstanceID() == weaponInstanceId)
                    {
                        weapons.RemoveAt(i);
                        break;
                    }
                }

                // Remove it from our 'hand'
                currentWeapon = null;
            }
        }

        void SelectWeapon(int index)
        {

            // Ensure we have a weapon in the wanted 'slot'
            if (weapons.Count > index && weapons[index] != null)
            {

                // Check if we already is carrying a weapon
                if (currentWeapon != null)
                {
                    // hide the weapon                
                    currentWeapon.gameObject.SetActive(false);
                }

                // Add our new weapon
                currentWeapon = weapons[index];

                // Show our new weapon
                currentWeapon.SetActive(true);
            }
        }
    }

