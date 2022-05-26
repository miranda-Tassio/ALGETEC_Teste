using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Algetec.ParamEvents;

public class TermometerDisplay : ConvertToFahrenheit, IMoveTo
{
    [SerializeField]TermometerData termometerData;
    [SerializeField]Transform initTarget;
    [SerializeField]Transform endTarget;
    [SerializeField][Range(1,10)]float increment;
    bool visorOn = false;

    void Update() => MoveTo();
    public void MoveTo()
    {
        if (!visorOn)
            transform.position = Vector3.Lerp(transform.position, initTarget.position, increment * Time.deltaTime);
        else
            transform.position = Vector3.Lerp(transform.position, endTarget.position, increment * Time.deltaTime);
    }
        public void HandleVisorOn(bool _visorOn) 
        {
            visorOn = _visorOn;
        }
}   
