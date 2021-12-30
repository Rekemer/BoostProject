using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float mainThrust = 100f;
    private Rigidbody rd;
    private AudioSource sfxSound;
    public bool CanMove { get; set; } = true;
    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
        sfxSound = GetComponent<AudioSource>();
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
                }
            }
        }
        else
        {
            if (sfxSound != null)
            {
                sfxSound.Stop();
            }
        }
    }

    private void RotateRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rd.freezeRotation = true;
            transform.Rotate(Vector3.forward);
            rd.freezeRotation = false;
        }
    }

    private void RotateLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rd.freezeRotation = true;
            transform.Rotate(-Vector3.forward);
            rd.freezeRotation = false;
        }
    }
}
