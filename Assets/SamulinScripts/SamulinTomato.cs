using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamulinTomato : MonoBehaviour
{
    public float speed = 200;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.back * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
