using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform tomato;
    public float distans;
    public float speed;
    public float howClose;
    // Start is called before the first frame update
    void Start()
    {
        tomato = GameObject.FindGameObjectWithTag("Tomato").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distans = Vector3.Distance(tomato.position, transform.position);

        if (distans <= howClose)
        {
            transform.LookAt(tomato);
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }

        if (distans <= 1.5f)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tomato")
        {
            Destroy(other.gameObject);
        }
    }
}
