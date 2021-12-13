using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamulinPlayerShoot : MonoBehaviour
{
    public GameObject tomato;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) { //jos painat mouse 1 pelaaja ampuu

            //instantiate ottaa sisäänsä ja katsoo tomaatinarvot, sen position sen rotaation ja suunnan mihin liikkuu
            Instantiate(tomato, transform.position, transform.rotation);
            tomato.transform.position = transform.position + transform.forward;
        }

    }
}
