using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cube", menuName = "Cube")]
public class CubeData : ScriptableObject
{
    public float heatConstant {get; private set;}
    public float coolConstant{get; private set;}
    public float minTemperature {get; private set;}
    public float maxTemperature {get; private set;}
    [HideInInspector]public bool onBunsen;


}
