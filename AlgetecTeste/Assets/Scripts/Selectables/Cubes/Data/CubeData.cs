using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cube", menuName = "Cube")]
public class CubeData : ScriptableObject
{
    public float heatConstant;
    public float coolConstant;
    public float minTemperature;
    public float maxTemperature;
}
