using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private int count;
    private Transform tomato;
    public float distans;
    public float speed;
    public TextMeshProUGUI TomatoCount;
    public GameObject LoseText;

    private BoxCollider enemybox;
    private Animator enemyAnim;


    void Start()
    {
        enemybox = GetComponent<BoxCollider>();
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        LoseText.SetActive(false);
    }


    void Update()
    {
        if (!tomato)
        {
            var tomatos = GameObject.FindGameObjectsWithTag("EnemyTomato");
            if (tomatos.Length > 0)
            {
                distans = Vector3.Distance(tomatos[0].transform.position, transform.position) * speed;

                transform.LookAt(tomatos[0].transform);
                GetComponent<Rigidbody>().AddForce(transform.forward);

            }
        }
        if (count < 1056) enemyAnim.SetFloat("Blend", 3);
        if (count >= 1056) enemyAnim.SetFloat("Blend", 0);

    }

    void SetCountText()
    {
        TomatoCount.text = count.ToString() + " Ouf  of 1056 Plant's Pickedup";

        if (count >= 1056)
        {
            LoseText.SetActive(true);
            Time.timeScale = 0;


        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyTomato"))
        {

            Destroy(other.gameObject);
            tomato = null;
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Tomato"))
        {
            Destroy(gameObject);
        }
    }
}