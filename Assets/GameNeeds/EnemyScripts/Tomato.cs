using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    private float upWall = 60f;
    private float downWall = -60f;
    public float speed;
    private Rigidbody tomatoRb;

    // Start is called before the first frame update

    void Start()
    {
        //sets rigidbody
        tomatoRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //makes tomato go forward when shot by default time times speed but it says vector3  back our world somehow changed  from forward to backward
        transform.Translate(Vector3.back * Time.deltaTime * speed);


        //if tomato position y goes upwall which is 60f it destroys it
        if (transform.position.y > upWall)
        {
            Destroy(gameObject);
        }
        //if tomato position y goes downwall which is -60f it destroys it
        if (transform.position.y < downWall)
        {
            Destroy(gameObject);
        }

    }

    //on trigger enter means when the object with this script equipped and when collided with an enemy tag it will destroy the object with the enemy tag
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
           
            Destroy(GameObject.FindWithTag("Enemy"));
        }

    }

}
