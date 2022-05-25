using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFinder : MonoBehaviour
{
    public InputData[] inputStrings;
    protected string lastButton = "";
    public string ConstrainedSetLastButton()
    {
        foreach(InputData inputData in inputStrings)
        {
            if (Input.GetButtonDown(inputData.inputName))
                return inputData.inputName;
        }
        return lastButton;
    }
}
