using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Algetec.ParamEvents;

public class CubeMain : Touchable
{
    bool TooglePath = true;
    [SerializeField] CubeData cubeData;
    [SerializeField] CubeDataEvent onSendCubeData;
    void Awake() => OnInteract.AddListener(GetComponent<CubeMove>().SetCanMove);
    public override void OnInteractableDown(string input)
    {
        base.OnInteractableDown();
        if (input != "Fire1")
            return;
        OnInteract.Invoke(TooglePath);
        onSendCubeData.Invoke(cubeData);
        TooglePath = !TooglePath;
    }
}
