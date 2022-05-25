using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour, IMoveTo
{
    [Range(1.01f, 10f)][SerializeField] float increment;
    [SerializeField] Transform bunsenTrans;
    [SerializeField] Transform initTrans;
    bool toBunsen = false;

    void Update()
    {
        if (toBunsen)
            MoveTo();
        else
            MoveTo();
    }
    public void MoveTo() 
    {
        Vector3 target = Vector3.zero;
        if (toBunsen)
            target = bunsenTrans.position;
        else
            target = initTrans.position;
            
        if(transform.position != target)
            transform.position = Vector3.Lerp(transform.position, target, increment * Time.deltaTime);
    }
    public void SetCanMove(bool _toBunsen) => toBunsen = _toBunsen;
}
