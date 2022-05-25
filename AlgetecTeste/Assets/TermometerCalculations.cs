using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermometerCalculations : MonoBehaviour
{
    [HideInInspector]public CubeData cubeData;
    [HideInInspector]float curTemperature = 25;
    bool isHeating = false;
    bool wasHeating = false;
    float timeElapsed;
    public IEnumerator UpdateTemperatureReference;
    void Awake() => UpdateTemperatureReference = UpdateTemperature(0.9f);

    void TemperatureEquation(float seconds, float initTemperature, float clampTemperature, float materialConstant)
    {
        curTemperature = initTemperature + (clampTemperature - initTemperature) * (1 - Mathf.Exp(-materialConstant * seconds));
    }

    void Heating(float time)=> TemperatureEquation(time, curTemperature, cubeData.maxTemperature, cubeData.heatConstant);

    void Cooling(float time) => TemperatureEquation(time, curTemperature, cubeData.minTemperature, cubeData.coolConstant);

    float CheckTemperature(float timeElapsed)
    {
        if (isHeating)
            Heating(timeElapsed);
        else
            Cooling(timeElapsed);
        return curTemperature;
    }

    IEnumerator UpdateTemperature(float duration)
    {
        var end = Time.time + duration;
        while(end > Time.time)
        {
            curTemperature = CheckTemperature(timeElapsed);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (isHeating == wasHeating)
            return;
        timeElapsed = 0;
        wasHeating = isHeating;
    }
}