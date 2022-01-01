using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class VisualEffectController : MonoBehaviour
{
    [SerializeField] VisualEffect _visualEffect;
    [SerializeField] VisualEffect _visualEffect2;

    private void Start()
    {
        _visualEffect.Stop();
        _visualEffect2.Stop();
    }

    public void PlayVisualEffect()
    {
        _visualEffect.Play();
        _visualEffect2.Play();
    }

    public void StopVisualEffect()
    {
        _visualEffect.Stop();
        _visualEffect2.Stop();
    }
}