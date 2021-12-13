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
        tomatoRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (transform.position.y > upWall)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < downWall)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            Debug.Log("Collided");
        }

    }


}
