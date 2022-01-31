using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        var rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            _rigidbodies.Add(rigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            _rigidbodies.Remove(rigidbody);
        }
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     other.gameObject.GetComponent<Rigidbody>().AddForce(direction);
    // }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var rigidbody1 in _rigidbodies)
        {
            if (rigidbody1 != null)
            {
                rigidbody1.AddForce( direction);
            }
        }
    }

    // private void OnDrawGizmos()
    // {
    //     //Debug.Log(direction.magnitude);
    //     //transform.TransformVector(transform.right);
    //     Gizmos.color = Color.red;
    //     var pos = transform.up * direction.y + transform.right * direction.x;
    //     pos += transform.position;
    //     sphere.gameObject.transform.position = pos;
    //     var up = transform.up + transform.position;
    //     var right = transform.right + transform.position;
    //     var force = direction.x * right + direction.y * up;
    //     Gizmos.DrawLine(transform.position,right);
    //      Gizmos.color = Color.blue;
    //     Gizmos.DrawLine(transform.position,up );
    //     // var pos = up * 1 + right * 4 + transform.position;
    //     //Gizmos.DrawSphere(pos,1);
    // }
}