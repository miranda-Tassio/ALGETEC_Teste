using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerMain : Grabbable
{
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
}
