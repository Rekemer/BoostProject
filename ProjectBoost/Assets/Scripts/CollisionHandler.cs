using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionHandler : MonoBehaviour
{
    private AudioPlayer _audioPlayer;
    private Destructable _destructable;

    private bool isTransitioning;
    // Start is called before the first frame update
    private void Awake()
    {
        _audioPlayer = GetComponent<AudioPlayer>();
        _destructable = GetComponent<Destructable>();

    }

    void Start()
    {
    }


    // might need to refactor this
    private void OnCollisionEnter(Collision other)
    {
        var movement = GetComponent<Movement>();
        if (movement.enabled == false) return;
        var effect = other.gameObject.GetComponent<ICanEffect>();
        var isFinish = other.gameObject.GetComponent<IFinish>();
       
        if (effect != null && isTransitioning == false)
        {
            isTransitioning = true;
           movement.CanMove = false;
            effect.PlayEffect();
            if ( _audioPlayer != null)
            {
                _audioPlayer.Play();
            }
            if (_destructable != null && isFinish == null )
            {
                _destructable.Activate();
            }
            
        }
    }
    
}