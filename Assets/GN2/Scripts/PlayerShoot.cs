using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject tomato;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        EnemyScript enemyScript;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            _ = Instantiate(tomato, transform.position, transform.rotation);
            tomato.transform.position = transform.position + transform.forward;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            Destroy(collision.gameObject);
        }

    }
}
