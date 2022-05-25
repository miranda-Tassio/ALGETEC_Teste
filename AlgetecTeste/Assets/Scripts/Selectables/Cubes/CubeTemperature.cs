using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTemperature : MonoBehaviour
{
    [HideInInspector]public float curTemperature = 25;
    [SerializeField] CubeData cubeData; 
    bool isHeating;
    IEnumerator UpdateTemperatureReference;
    void Start() => UpdateTemperatureReference = UpdateTemperature(0.9);
    public IEnumerator UpdateTemperature(float duration)
    {
        var end = Time.time + duration;
        float timeElapsed;
        while(end > Time.time)
        {
            checkTemperature(timeElapsed);
            yield return new WaitForSeconds(0.1f);
            timeElapsed += Time.deltaTime;
        }
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
