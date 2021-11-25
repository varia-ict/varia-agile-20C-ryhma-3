using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushGrow : MonoBehaviour
{
    private float _dayTime;
    private float _growPerTime = 0.1f;
    private float _timeToFullSize = 1;
    private int _growPerTimeOfDay = 12;
    private float _x;
    private float _y;
    private float _z;
    public float xMaxScale;

    // Start is called before the first frame update
    void Start()
    {
        // haetaan päivän mitta LightingManagerista
        _dayTime = LightingManager.Instance.TimeOfDay;
        StartCoroutine(GrowPlant());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject);
        // tämän kasvin koko nyt
        _x = gameObject.transform.localScale.x;
        _y = gameObject.transform.localScale.y;
        _z = gameObject.transform.localScale.z;

    }

    private IEnumerator GrowPlant()
    {
        //var wait = new WaitForSeconds(1);
        var wait = new WaitForSeconds((_dayTime / _growPerTimeOfDay) * _timeToFullSize);
        yield return wait;

        gameObject.transform.localScale = new Vector3(
          x: _x + _growPerTime,
          y: _y + _growPerTime,
          z: _z + _growPerTime
        );

        if (_x < xMaxScale)
        {
            StartCoroutine(GrowPlant());
        }


    }


}