using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermometerInterface : MonoBehaviour
{
    [SerializeField] TermometerData termometerData;
    bool visorOn;
    public void SetVisorOn(bool _visorOn) => visorOn = _visorOn;
}
