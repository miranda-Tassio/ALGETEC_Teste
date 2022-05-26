using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Algetec.ParamEvents;

public class Grabbable: Interactable, IInteractableUp, IInteractableDown
{
    protected BoolEvent OnInteract = new BoolEvent();
    protected BoolEvent OnSustainInteract = new BoolEvent();
    public HandlerType handlerType;

    public virtual void OnInteractableDown(string input = "") {}

    public virtual void OnInteractableUp(string input = "") {}

}
