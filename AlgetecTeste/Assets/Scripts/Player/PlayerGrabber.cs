using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGrabber : InputFinder
{
    [SerializeField]UnityEvent OnInteract = new UnityEvent();
    Touchable currentSingleTarget;
    Grabbable currentGrabbableTarget;

    void Update()
    {
        base.lastButton = base.ConstrainedSetLastButton();

        if (base.lastButton == "")
            return;
        
        if (Input.GetButtonDown(base.lastButton))
        {
            OnInteract.Invoke();
            if (currentSingleTarget != null)
            {
                currentSingleTarget.OnInteractableDown(base.lastButton);
                currentSingleTarget = null;
                base.lastButton = "";
            }
        
            if (currentGrabbableTarget != null)
                currentGrabbableTarget.OnInteractableDown(base.lastButton);
        }
        
        if (currentGrabbableTarget == null)
            return;
        
        if (Input.GetButtonUp(base.lastButton))
        {
            currentGrabbableTarget.OnInteractableUp(base.lastButton);
            currentGrabbableTarget = null;
            base.lastButton = "";
        }
    }
    public void SetCurrentGrabbableTarget(Grabbable _currentGrabbableTarget) => currentGrabbableTarget = _currentGrabbableTarget;
    public void SetCurrentSingleTarget(Touchable _currentSingleTarget) => currentSingleTarget = _currentSingleTarget;
}
