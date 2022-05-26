using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BurnerMain : Grabbable
{
    public static Action<CubeData> OnSetCube;
    [SerializeField] ParticleSystem fireParticles;
    [HideInInspector] public CubeData slot;
    [HideInInspector] public bool flameOn = false;

    void Awake()
    {
        base.OnSustainInteract.AddListener(ToggleForFlameOn);
        base.OnInteract.AddListener(ToggleForFlameOn);
    }
    public override void OnInteractableDown(string input)
    {
        base.OnInteractableDown();
        if (input != "Fire1")
            return;
        if (!flameOn)
            base.OnSustainInteract.Invoke(true);
        else
            base.OnInteract.Invoke(false);
    }

    public override void OnInteractableUp(string input)
    {
        base.OnInteractableUp();
        if (!flameOn)
            base.OnSustainInteract.Invoke(false);
    }

    public void SetCubeData(CubeData _cubeData)
    {
        slot = _cubeData;
        OnSetCube?.Invoke(slot);
    }

    public void ToggleForFlameOn(bool _toogleBunsen)
    {
        if (_toogleBunsen)
        {
            StartCoroutine(TurningFlameOn(3f));
            fireParticles.Play();
        }
        else
        {
            StopAllCoroutines();
            flameOn = false;
            fireParticles.Stop();
        }
    }
    IEnumerator TurningFlameOn(float duration)
    {
        float end = Time.time + duration;
        yield return new WaitForSeconds(duration + 0.1f);
        if (end < Time.time)
            flameOn = true;
        else
            flameOn = false;
    }
}
