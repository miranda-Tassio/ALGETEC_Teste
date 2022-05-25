using UnityEngine;
using UnityEngine.Events;

namespace Algetec.ParamEvents
{
    [System.Serializable]public class BoolEvent : UnityEvent<bool>{}
    public class GrabbableEvent : UnityEvent<Grabbable>{}
    public class TouchableEvent : UnityEvent<Touchable>{}
    [System.Serializable] public class CubeDataEvent : UnityEvent<CubeData>{}
}
