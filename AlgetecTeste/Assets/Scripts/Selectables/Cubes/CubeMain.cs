using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Algetec.ParamEvents;

public class CubeMain : Touchable
{
    static bool measuringSpaceOcuppied;
    bool isOnTable = true;
    [SerializeField] CubeData cubeData;
    [SerializeField] CubeDataEvent onSendCubeData;
    void Awake() => OnInteract.AddListener(GetComponent<CubeMove>().SetCanMove);
    public override void OnInteractableDown(string input)
    {
        base.OnInteractableDown();
        if (input != "Fire1")
            return;
        if (isOnTable && measuringSpaceOcuppied)
            return;    
        OnInteract.Invoke(isOnTable);
        isOnTable = !isOnTable;

        if (!isOnTable)
            onSendCubeData.Invoke(cubeData);

        measuringSpaceOcuppied = !isOnTable;
    }
}
