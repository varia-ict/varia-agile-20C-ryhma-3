using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushGrow : MonoBehaviour
{
    private float _dayTime; // päivän pituus (LightningManager)
    public float GrowPerTime = 0.3f; // kuinka paljon kasvi kasvaa kerrallaan
    private float _timeToFullSize = 8; // kuinka paljon aikaa kasvi vaatii kasvaakseen täyteen mittaan
    private int _growPerTimeOfDay = 24; // kuinka monta kertaa kasvi kasvaa peli vuorokaudessa
    private float _x; // kasvin x scale
    private float _y; // ..
    private float _z; // ..

    public int period = 10;
    public float xMaxScale; // kasvin max scale

    // Start is called before the first frame update
    void Start()
    {
        _dayTime = LightingManager.Instance.TimeOfDay; // haetaan päivän mitta LightingManagerista.
        StartCoroutine(GrowPlant()); // aloitetaan kasvin kasvuprosessi
    }

 

    private IEnumerator GrowPlant()
    {
        var wait = new WaitForSeconds(period);
        //var wait = new WaitForSeconds(1);
        //var wait = new WaitForSeconds((_dayTime / _growPerTimeOfDay) * _timeToFullSize);
        yield return wait;

        Debug.Log(gameObject);
        // tämän kasvin koko nyt
        _x = gameObject.transform.localScale.x;
        _y = gameObject.transform.localScale.y;
        _z = gameObject.transform.localScale.z;

        gameObject.transform.localScale = new Vector3(
          x: _x + GrowPerTime,
          y: _y + GrowPerTime,
          z: _z + GrowPerTime
        );

        if (_x < xMaxScale)
        {
            StartCoroutine(GrowPlant());
        }


    }


}