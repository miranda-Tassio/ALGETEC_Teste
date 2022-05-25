using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [Range(1,15)]
    [SerializeField] float sensitivity = 3.5f;
    [Range(0.01f,0.9f)]
    [SerializeField] float mouseDrag = 0.3f;
    [SerializeField] bool isInverted = false;
    Vector2 mouseDeltaVector;
    Vector2 smoothMouseDelta;
    float pitch;
    void Update()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        smoothMouseDelta = Vector2.SmoothDamp(smoothMouseDelta, mouseDelta, ref mouseDeltaVector, mouseDrag);

        pitch = !isInverted? pitch - smoothMouseDelta.y * sensitivity : pitch + smoothMouseDelta.y * sensitivity;

        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);

        transform.localEulerAngles = Vector3.right * pitch;

        transform.parent.Rotate(Vector3.up * mouseDelta.x * sensitivity);
        
    }
}
