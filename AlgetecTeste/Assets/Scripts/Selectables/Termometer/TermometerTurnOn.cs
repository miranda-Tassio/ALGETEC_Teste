using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermometerTurnOn : MonoBehaviour, IMoveTo
{
    [Range(1.01f, 10f)][SerializeField] float increment;
    [SerializeField]float minAngle;
    [SerializeField]float maxAngle;
    bool turnOn = false;
    float curAngle;

    void Update()
    {
        if (turnOn)
            MoveTo();
        else
            MoveTo();
    }
    public void MoveTo()
    {
        float whichAngle;
        if(turnOn)
            whichAngle = maxAngle;
        else
            whichAngle = minAngle;
        curAngle = Mathf.LerpAngle(curAngle, whichAngle, increment * Time.deltaTime);
        transform.eulerAngles = new Vector3(curAngle, -90, 0);
    }

    public void SetTurnOn(bool _turnOn) => turnOn = _turnOn;
}
