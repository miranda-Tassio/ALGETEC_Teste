using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Algetec.ParamEvents;

public class CubeMain : Touchable
{
    bool toogleTarget = true;
    [SerializeField] CubeData cubeData;
    [SerializeField] CubeDataEvent onSendCubeData;
    void Awake() => OnInteract.AddListener(GetComponent<CubeMove>().SetCanMove);
    public override void OnInteractableDown(string input)
    {
        base.OnInteractableDown();
        if (input != "Fire1")
            return;
            
        OnInteract.Invoke(toogleTarget);
        toogleTarget = !toogleTarget;

        if (toogleTarget)
            onSendCubeData.Invoke(cubeData);
    }
}
