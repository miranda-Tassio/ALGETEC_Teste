using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTemperature : MonoBehaviour
{
    [HideInInspector]public float curTemperature = 25;
    [SerializeField] CubeData cubeData; 
    bool isHeating;
    float timeTracker;
    int timeSinceHeatChange;
    void Update()
    {
        timeTracker += Time.deltaTime;
    }

    void TemperatureEquation(float seconds, float initTemperature, float clampTemperature, float materialConstant)
    {
        curTemperature = initTemperature + (clampTemperature - initTemperature) * (1 - Mathf.Exp(-materialConstant * seconds));
    }

    void Heating(float time)=> TemperatureEquation(time, curTemperature, cubeData.maxTemperature, cubeData.heatConstant);

    void Cooling(float time) => TemperatureEquation(time, curTemperature, cubeData.minTemperature, cubeData.coolConstant);

    public float checkTemperature()
    {
        if (isHeating)
            Heating(timeSinceHeatChange);
        else
            Cooling(timeSinceHeatChange);

        return curTemperature;
    }
}
