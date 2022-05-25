using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertToFahrenheit : MonoBehaviour, ITemperatureConverter
{
    public float ConvertToUnit(float value) => value * 1.8f + 32;
}
