using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float mainThrust = 100f;
    [SerializeField] private float RotationSpeed = 50f;
    private Rigidbody rd;
    private AudioSource sfxSound;
    private ParticleSystemController _particleSystemController;
    private VisualEffectController _visualEffectController;
    public bool CanMove { get; set; } = true;
    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
        sfxSound = GetComponent<AudioSource>();
        _particleSystemController = GetComponent<ParticleSystemController>();
        _visualEffectController = GetComponent<VisualEffectController>();
    }

    void Start()
    {
      
    }
     

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            Thrust();
            RotateRight();
            RotateLeft();
        }
        else
        {
            _visualEffectController.StopVisualEffect();
        }
       
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rd.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
            if (sfxSound != null)
            {
                if (!sfxSound.isPlaying)
                {
                    sfxSound.Play();
                    _visualEffectController.PlayVisualEffect();
                }
            }
        }
        else
        {
            if (sfxSound != null)
            {
                sfxSound.Stop();
               
            }
            _visualEffectController.StopVisualEffect();
        }
    }

    private void RotateRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rd.freezeRotation = true;
            transform.Rotate(Vector3.forward * RotationSpeed);
            rd.freezeRotation = false;
        }
    }

    private void RotateLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rd.freezeRotation = true;
            transform.Rotate(-Vector3.forward * RotationSpeed);
            rd.freezeRotation = false;
        }
    }
}