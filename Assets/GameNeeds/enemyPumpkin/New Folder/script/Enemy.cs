using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private Transform tomato;
    public float distans;
    public float speed = 10.0f;
    public float howClose;
    public bool enemyAttack;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        //tomato = GameObject.FindGameObjectWithTag("Tomato").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!tomato)
        {
            //tomato = GameObject.FindGameObjectWithTag("Tomato").transform;
            var tomatos = GameObject.FindGameObjectsWithTag("Tomato");
            if(tomatos.Length > 0)
            {
                distans = Vector3.Distance(tomatos[0].transform.position, transform.position);

                transform.LookAt(tomatos[0].transform);
                GetComponent<Rigidbody>().AddForce(transform.forward * speed);

            }
        }
        //if (distans <= howClose)
        //{
        //    transform.LookAt(tomato);
        //    GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        //}

        if (distans <= 2.0f)
        {

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tomato"))
        {
            enemyAttack = true;
            Destroy(other.gameObject);
            tomato = null;
        }
    }
}
