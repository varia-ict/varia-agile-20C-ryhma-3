using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private int count;
    private Transform tomato;
    public float distans;
    public float speed;
    //public float howClose;
    public bool enemyAttack;

    private BoxCollider enemybox;
    private Animator enemyAnim;


    void Start()
    {
        enemybox = GetComponent<BoxCollider>();
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody>();
        count = 0;
    }


    void Update()
    {
        if (!tomato)
        {
            var tomatos = GameObject.FindGameObjectsWithTag("Tomato");
            if(tomatos.Length > 0)
            {
                distans = Vector3.Distance(tomatos[0].transform.position, transform.position) * speed;

                transform.LookAt(tomatos[0].transform);
                GetComponent<Rigidbody>().AddForce(transform.forward);

            }
        }
        if (count < 2) enemyAnim.SetFloat("Blend", 1);
        if (count >= 2) enemyAnim.SetFloat("Blend", 0);

    }

    public void Idle()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tomato"))
        {

            count = count + 1;
            enemyAttack = true;
            Destroy(other.gameObject);
            tomato = null;
        }
    }
}
