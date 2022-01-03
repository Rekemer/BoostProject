using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class FinishPoint : MonoBehaviour, ICanSound, IFinish
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private ParticleSystem _particleSystem;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    

    public void PlayEffect()
    {
        if (_source != null)
        {
            _source.clip = clip;
            _source.Play();
        }

        if (_particleSystem != null)
        {
           _particleSystem.Play();
        }
       
    }
}