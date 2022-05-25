using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermometerInterface : MonoBehaviour
{
    [SerializeField] float numericText; 
    bool visorOn;
    public void SetVisorOn(bool _visorOn) => visorOn = _visorOn;
}
