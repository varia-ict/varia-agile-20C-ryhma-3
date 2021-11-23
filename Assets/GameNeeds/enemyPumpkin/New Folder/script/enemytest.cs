using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytest : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody enemyRb;
    public GameObject tomato;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        tomato = GameObject.Find("Tomato");
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce((tomato.transform.position - transform.position) * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tomato"))
        {
            Destroy(other.gameObject);
        }
    }
}
