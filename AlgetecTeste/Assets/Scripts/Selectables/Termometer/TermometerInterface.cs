using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Algetec.ParamEvents;

public class TermometerInterface : MonoBehaviour
{
    [SerializeField]TermometerDisplay termometerDisplay;
    BoolEvent OnVisorOn = new BoolEvent();
    [SerializeField]TermometerData termometerData;

    void Start() => OnVisorOn.AddListener(termometerDisplay.HandleVisorOn);
    public void SetVisorOn(bool _visorOn) => OnVisorOn.Invoke(_visorOn);
}
