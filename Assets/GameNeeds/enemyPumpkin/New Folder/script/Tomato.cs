using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    public float speed;
    private Rigidbody tomatoRb;
    public float breakpoint = 48f;
    // Start is called before the first frame update
    void Start()
    {
        tomatoRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.back * Time.deltaTime * speed);

        if (transform.position.y > breakpoint)
        {
            Debug.Log(transform.position.y);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collidoi " + other);
        Destroy(gameObject);
    }
}
