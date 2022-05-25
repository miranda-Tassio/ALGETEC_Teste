using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TermometerMain : Grabbable
{
    CubeTemperature cubeTemperature;
    bool turnedOn = false;
    bool updateFlag = false;
    float uptimeDuration;
    void Awake() 
    {
        base.OnInteract.AddListener(GetComponent<TermometerTurnOn>().SetTurnOn);
        base.OnSustainInteract.AddListener(GetComponent<TermometerInterface>().SetVisorOn);
    }
    public override void OnInteractableDown(string input)
    {
        base.OnInteractableDown();
        if(input == "Fire1")
        {
            if(turnedOn)
            {
                base.OnSustainInteract.Invoke(true);
                updateFlag = false;
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
        if (input == "Fire1")
            uptimeDuration = 15;
            base.OnSustainInteract.Invoke(false);
            updateFlag = true;
    }

    void Update()
    {
        if(!updateFlag)
            return;

        if (uptimeDuration <= 0)
        {
            base.OnSustainInteract.Invoke(true);
            base.OnInteract.Invoke(false);
            turnedOn = false; 
            return;
        }
        uptimeDuration -= Time.deltaTime;
    }
}
