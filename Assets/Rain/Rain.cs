using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{


    float timer;
    public ParticleSystem SysRain;
    AudioSource audioRain;

    private int dayNro;

    // Start is called before the first frame update
    void Start()
    {
        audioRain = SysRain.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        dayNro = LightingManager.Instance.DayNro;
        // rain start 50%
        var random = Random.value > 0.5f;

        // rain can start only even days;
        var rainyDay = dayNro % 2 == 0;

        Debug.Log($"d: {dayNro} b: {dayNro % 2 == 0}");

        if (rainyDay && random)
        {
            Debug.Log("Sadepäivä");
            StartRain();
        }
    }

    void StartRain()
    {
        /*timer = timer + Time.deltaTime;
        if (timer >= 5 && timer < 25)
        {
            SysRain.gameObject.SetActive(true);
            audioRain.volume = audioRain.volume + 0.0005f;
            SysRain.maxParticles = SysRain.maxParticles + 10;
        }*/

        timer = timer + Time.deltaTime;
        if (timer >= 5 && timer < 50)
        {
            SysRain.gameObject.SetActive(true);
            audioRain.volume = audioRain.volume + 0.001f;
            SysRain.maxParticles = SysRain.maxParticles + 10;

        }
        else
        {
            RainStop();
            RainEffectFalse();
        }
        return;
    }

    void RainStop()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 60)
        {
            audioRain.volume = audioRain.volume - 0.0004f;
            SysRain.maxParticles = SysRain.maxParticles - 10;
        }
    }

    void RainEffectFalse()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 200)
        {
            SysRain.gameObject.SetActive(false);
        }
            

    }
}

