using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private int count;
    private Transform tomato;
    public float distans;
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject loseTextObject;

    private BoxCollider enemybox;
    private Animator enemyAnim;


    void Start()
    {
        enemybox = GetComponent<BoxCollider>();
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        loseTextObject.SetActive(false);
    }


    void Update()
    {
        if (!tomato)
        {
            var tomatos = GameObject.FindGameObjectsWithTag("EnemyTomato");
            if(tomatos.Length > 0)
            {
                distans = Vector3.Distance(tomatos[0].transform.position, transform.position) * speed;

                transform.LookAt(tomatos[0].transform);
                GetComponent<Rigidbody>().AddForce(transform.forward);

            }
        }
        if (count < 6) enemyAnim.SetFloat("Blend", 3);
        if (count >= 6) enemyAnim.SetFloat("Blend", 0);

    }

    void SetCountText()
    {
        countText.text = "Tomato_PickedUp : " + count.ToString();

        if (count >= 6)
        {
            loseTextObject.SetActive(true);
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
