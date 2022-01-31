using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent( typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    public AudioClip musicClip;
    public bool IsPlaying
    {
        get => _audioSource.isPlaying;
    }
    private AudioSource _audioSource;
    // public AudioClip[] winClips;
    // public AudioClip[] loseClips;
    // public AudioClip[] bonusClips;
    [Range(0, 1)] public float musicVolume;
    [Range(0, 1)] public float fxVolume;
    public float lowPitch = 0.95f;
    public float highPitch = 1.05f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        
    }
    public void Play()
    {
        _audioSource.clip = musicClip;
        _audioSource.Play();
    }
    public void Stop()
    {
        _audioSource.Stop();
    }
   

   
}
