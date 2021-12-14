using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    //needed objects and rigidbodies with counters
    private Rigidbody enemyRb;
    private int count;
    private Transform tomato;
    public float distans;
    public float speed;
    public TextMeshProUGUI CountTomato;
    public GameObject LoseText;

    private BoxCollider enemybox;
    private Animator enemyAnim;


    void Start()
    {

        enemybox = GetComponent<BoxCollider>();
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody>();
        //sets count number to 0 and activates count text and it will set the losetext to false
        count = 0;
        SetCountText();
        LoseText.SetActive(false);
    }


    void Update()
    {
        if (!tomato)
        {
            //finds gameobject with enemy tomato tag
            var tomatos = GameObject.FindGameObjectsWithTag("EnemyTomato");
            if (tomatos.Length > 0)
            {
                distans = Vector3.Distance(tomatos[0].transform.position, transform.position) * speed;
                //they search for tomatos which is mentioned above it is enemytomato tag and they walk forward torwards object
                transform.LookAt(tomatos[0].transform);
                GetComponent<Rigidbody>().AddForce(transform.forward);

            }
        }
        //if plants are less than 980 animation will still be playing but if reached 980 and more it will stop the current animation
        if (count < 980) enemyAnim.SetFloat("Blend", 3);
        if (count >= 980) enemyAnim.SetFloat("Blend", 0);

    }

    void SetCountText()
    {
        CountTomato.text = count.ToString() + " Ouf  of 980 Plant's Pickedup";
        //if they collect 980 plants it the losetext will be set to true and time scale to 0 which makes the realworld stopped
        if (count >= 980)
        {
            LoseText.SetActive(true);
            Time.timeScale = 0;


        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //if enemy collides with enemytomato it will destroy the tomato and removes the data it will also add 1 count to the tostring count and sets it
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