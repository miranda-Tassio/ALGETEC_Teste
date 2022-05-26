using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TermometerMain : Grabbable
{
    TermometerCalculations termometerCalculations;
    bool turnedOn = false;
    bool updateFlag = false;
    bool isMeasuring = false;
    float uptimeDuration;
    void Awake()
    {
        termometerCalculations = GetComponent<TermometerCalculations>();
        base.OnInteract.AddListener(GetComponent<TermometerTurnOn>().SetTurnOn);
        base.OnSustainInteract.AddListener(GetComponent<TermometerInterface>().SetVisorOn);
    }
    public override void OnInteractableDown(string input)
    {
        base.OnInteractableDown();
        if (input == "Fire1")
        {
            if (turnedOn)
            {
                base.OnSustainInteract.Invoke(true);
                termometerCalculations.StartUpdateTemperature();
                updateFlag = false;
                isMeasuring = true;
            }
            else
            {
                base.OnInteract.Invoke(true);
                turnedOn = true;
                updateFlag = false;
            }
        }
    }

    public override void OnInteractableUp(string input)
    {
        base.OnInteractableUp();
        if (!isMeasuring)
            return;
        if (input == "Fire1")
        {
            if (termometerCalculations.UpdateTemperatureReference != null)
                termometerCalculations.StopCoroutine(termometerCalculations.UpdateTemperatureReference);
            uptimeDuration = 15;
            updateFlag = true;
        }
    }

    void Update()
    {
        if (!updateFlag)
            return;

        if (uptimeDuration <= 0)
        {
            base.OnSustainInteract.Invoke(false);
            base.OnInteract.Invoke(false);
            turnedOn = false;
            isMeasuring = false;
            return;
        }
        uptimeDuration -= Time.deltaTime;
    }
}
