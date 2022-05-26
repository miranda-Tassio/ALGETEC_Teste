using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Algetec.ParamEvents;

public class TermometerCalculations : MonoBehaviour
{
    [SerializeField] FloatEvent OnTemperatureChange = new FloatEvent();
    [SerializeField] BurnerMain burnerMain;
    CubeData cubeData;
    [HideInInspector] float curTemperature = 25;
    bool isHeating = false;
    bool wasHeating = false;
    float timeElapsed;
    public Coroutine UpdateTemperatureReference;

    void OnEnable() => BurnerMain.OnSetCube += HandleCubeSet;
    void OnDisable() => BurnerMain.OnSetCube -= HandleCubeSet;
    //void Awake() => UpdateTemperatureReference = UpdateTemperature(0.9f);

    void TemperatureEquation(float seconds, float initTemperature, float clampTemperature, float materialConstant) =>
        curTemperature = initTemperature + (clampTemperature - initTemperature) * (1 - Mathf.Exp(-materialConstant * seconds));

    void Heating(float time) => TemperatureEquation(time, curTemperature, cubeData.maxTemperature, cubeData.heatConstant);

    void Cooling(float time) => TemperatureEquation(time, curTemperature, cubeData.minTemperature, cubeData.coolConstant);

    float CheckTemperature(float timeElapsed)
    {
        if (isHeating)
            Heating(timeElapsed);
        else
            Cooling(timeElapsed);
        return curTemperature;
    }
    public void StartUpdateTemperature()
    {
        UpdateTemperatureReference = StartCoroutine(UpdateTemperature(0.9f));
    }
    IEnumerator UpdateTemperature(float duration)
    {
        if (cubeData == null)
            yield break;

        var end = Time.time + duration;
        while (end > Time.time)
        {
            curTemperature = CheckTemperature(timeElapsed);
            OnTemperatureChange?.Invoke(curTemperature);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void HandleCubeSet(CubeData _cubeData) => cubeData = _cubeData;
    void Update()
    {
        burnerMain.slot = cubeData;

        if (burnerMain.flameOn)
            isHeating = true;
        else
            isHeating = false;

        timeElapsed += Time.deltaTime;

        if (isHeating == wasHeating)
            return;

        timeElapsed = 0;
        wasHeating = isHeating;
    }
}