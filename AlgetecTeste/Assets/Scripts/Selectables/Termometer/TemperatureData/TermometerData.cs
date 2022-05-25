using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TemperatureData", menuName = "Temperature")]
public class TermometerData : ScriptableObject 
{
    [SerializeField]float currentTemperature;
    [SerializeField]string currentUnit;
    [SerializeField]float maxTemperature;
    
}



