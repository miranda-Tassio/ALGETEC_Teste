using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerMain : Grabbable
{
    CubeData slot;
    bool flameOn = true;
    public override void OnInteractableDown(string input)
    {
        base.OnInteractableDown();
        if(input != "Fire1" || !flameOn)
            return;
        base.OnSustainInteract.Invoke(true);
    }

    public override void OnInteractableUp(string input)
    {
        base.OnInteractableUp();
        base.OnSustainInteract.Invoke(false);
    }
    public void SetCubeData(CubeData _cubeData) 
    {
        slot = _cubeData;
        GetComponent<BunsenCalculations>().cubeData = _cubeData;
    }
}
