using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFx : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
       
    }

}