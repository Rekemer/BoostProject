using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class FinishPoint : MonoBehaviour, ICanSound 
{
    [SerializeField] private AudioClip clip;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    

    public void PlaySound()
    {
        _source.clip = clip;
       _source.Play();
    }
}