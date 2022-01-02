using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] Vector2 direction;

    void Start()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(direction);
    }

    // Update is called once per frame
    void Update()
    {
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