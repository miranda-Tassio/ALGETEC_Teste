using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Algetec.ParamEvents;


public class Touchable : Interactable, IInteractableDown
{
    protected BoolEvent OnInteract = new BoolEvent();

    public HandlerType handlerType;

    public virtual void OnInteractableDown(string input = ""){}
}
