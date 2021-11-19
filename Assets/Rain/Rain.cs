using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{


    float timer;
    public ParticleSystem SysRain;
    AudioSource audioRain;
    public float randomTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        audioRain = SysRain.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            timer = timer + Time.deltaTime;
            if (timer >= 5 && timer < 50)
            {
                SysRain.gameObject.SetActive(true);
                audioRain.volume = audioRain.volume + 0.001f;
                SysRain.maxParticles = SysRain.maxParticles + 10;

            }
            else
            {
                timer = timer + Time.deltaTime;
                if (timer >= 0)
                    {
                        SysRain.gameObject.SetActive(true);
                        audioRain.volume = audioRain.volume - 0.0004f;
                        SysRain.maxParticles = SysRain.maxParticles - 10;
                    }
            }
    }   
}
