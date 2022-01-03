using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Obstacle : MonoBehaviour, ICanSound
{
    [SerializeField] private AudioClip clip;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    

    public void PlayEffect()
    {
        _source.clip = clip;
        _source.Play();
    }
}
