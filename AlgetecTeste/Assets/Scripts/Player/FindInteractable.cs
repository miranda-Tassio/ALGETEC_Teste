using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Algetec.ParamEvents;

public class FindInteractable : MonoBehaviour
{
    GrabbableEvent OnGetGrabbable = new GrabbableEvent();
    TouchableEvent OnGetTouchable = new TouchableEvent();
    [SerializeField][Range(1f,10f)]float maxDistance;
    RaycastHit targetInfo;
    bool hasTarget;
    [SerializeField]PlayerGrabber playerGrabber;
    Grabbable grabbableTarget;
    Touchable touchableTarget;
    Outline outliner;

    void Start()
    {
        OnGetTouchable.AddListener(playerGrabber.SetCurrentSingleTarget);
        OnGetGrabbable.AddListener(playerGrabber.SetCurrentGrabbableTarget);
    }
    void Update()
    {
        int bitmask = 1 << 6;
        hasTarget = Physics.Raycast(transform.position, transform.forward, out targetInfo, maxDistance, bitmask);
    }

    public void TryGetInteractable()
    {
        if (!hasTarget)
            return;
        var grabbableTarget = targetInfo.transform.GetComponent<Grabbable>();
        if (grabbableTarget != null)
            OnGetGrabbable.Invoke(grabbableTarget);
        else
        {
        var touchableTarget = targetInfo.transform.GetComponent<Touchable>();
            OnGetTouchable.Invoke(touchableTarget);
        }
    }
}
