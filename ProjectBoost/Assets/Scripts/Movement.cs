using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float mainThrust = 100f;
    private Rigidbody rd;

    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
    }

    void Start()
    {
      
    }
     

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rd.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rd.freezeRotation = true;
            transform.Rotate(Vector3.forward);
            rd.freezeRotation = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rd.freezeRotation = true;
            transform.Rotate(-Vector3.forward);
            rd.freezeRotation = false;
        }
    }
    
    
}
