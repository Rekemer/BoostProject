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
    private AudioPlayer _audioPlayer ;
    private VisualEffectController _visualEffectController;
    [SerializeField] private ParticleSystemController _particleSystem;
    public bool CanMove { get; set; } = true;
    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
        _audioPlayer = GetComponent<AudioPlayer>();
        _visualEffectController = GetComponent<VisualEffectController>();
        _particleSystem = GetComponent<ParticleSystemController>();

    }

    void Start()
    {
        
    }
     

    // Update is called once per frame
    void FixedUpdate()
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
            _audioPlayer.Stop();
            _particleSystem.StopParticles();
        }
       
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rd.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
            if (_audioPlayer != null)
            {
                if (!_audioPlayer.IsPlaying)
                {
                    _audioPlayer.Play();
                    _visualEffectController.PlayVisualEffect();
                    _particleSystem.PlayParticle();
                }
            }
        }
        else
        {
            if (_audioPlayer != null)
            {
                _audioPlayer.Stop();
               
            }
            _visualEffectController.StopVisualEffect();
            _particleSystem.StopParticles();
        }
    }

    private void RotateRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //rd.freezeRotation = true;
            // Quaternion deltaRotation = Quaternion.Euler(Vector3.forward * RotationSpeed * Time.fixedDeltaTime);
             //rd.MoveRotation(rd.rotation * deltaRotation);
           transform.Rotate(Vector3.forward * RotationSpeed);
            //rd.freezeRotation = false;
            
        }
    }

    
    private void RotateLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
          //  rd.freezeRotation = true;
           // Quaternion deltaRotation = Quaternion.Euler(-Vector3.forward * RotationSpeed * Time.fixedDeltaTime);
           //  rd.MoveRotation(rd.rotation * deltaRotation);
            transform.Rotate(-Vector3.forward * RotationSpeed);
           // rd.freezeRotation = false;
            
        }
    }
}