using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private AudioSource _audioSource;

    private bool isTransitioning;
    // Start is called before the first frame update
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
    }


    // might need to refactor this
    private void OnCollisionEnter(Collision other)
    {
        var sound = other.gameObject.GetComponent<ICanSound>();
        if (sound != null && isTransitioning == false)
        {
            isTransitioning = true;
            GetComponent<Movement>().CanMove = false;
            _audioSource.Stop();
            sound.PlaySound();
        }
    }
}