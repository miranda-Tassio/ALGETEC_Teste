using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(5f, 25f)]
    [SerializeField] float speed;
    [Range(.1f, .9f)]
    [SerializeField] float acceleration;
    [SerializeField] CharacterController ctrl;
    Vector2 smoothDir  = Vector2.zero;
    Vector2 dirVector = Vector2.zero;

    void Update()
    {
        //Gather Input
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        dir.Normalize();
        
        //Smoothing Input
            SmoothInput(dir);
        //Moving Player
        Vector3 movement = (transform.forward * smoothDir.y + transform.right * smoothDir.x) * speed * Time.deltaTime;
        ctrl.Move(movement);
    }

    void SmoothInput(Vector2 inputDir) => smoothDir = Vector2.SmoothDamp(smoothDir, inputDir, ref dirVector, acceleration);

}