using System;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 600)] public float TimeOfDay;
    public int DayNro = 1;
    private int nextDay = 2;

    private float dayTime = 600;

    public static LightingManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null) throw new Exception("Only one LightingManager is allowed");
        Instance = this;
    }

    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= dayTime; //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / dayTime);
        }

        // jos päivä ei ole vaihtunut ja peliaika on alle .5f, päivitä päivämäärä.
        if (DayNro != nextDay && TimeOfDay < .5f)
        {
            DayNro = nextDay;
          
        }

        // jos pelipäivä on päivitetty mutta nextday on yhä nykyinen päivä, päivitä nextday.
        if (nextDay == DayNro && TimeOfDay > .5f)
        {
            nextDay++;
           
        }
    }


    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }




    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }

}