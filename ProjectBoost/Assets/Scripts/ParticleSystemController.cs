using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    private void Awake()
    {
       
    }

    public void PlayParticle()
    {
        _particle.Play();
    }

    public void StopParticles()
    {
        _particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
