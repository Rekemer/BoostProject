using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private AudioSource _thrustSound;
    private Destructable _destructable;

    private bool isTransitioning;
    // Start is called before the first frame update
    private void Awake()
    {
        _thrustSound = GetComponent<AudioSource>();
        _destructable = GetComponent<Destructable>();

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
            sound.PlaySound();
            if ( _thrustSound != null)
            {
                _thrustSound.Stop();
            }
            if (_destructable != null)
            {
                _destructable.Activate();
            }
            
        }
    }
}