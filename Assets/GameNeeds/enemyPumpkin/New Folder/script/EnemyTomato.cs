using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTomato : MonoBehaviour
{
    private Rigidbody tomRb;

    void Start()
    {
        tomRb = GetComponent<Rigidbody>();
    }
}
