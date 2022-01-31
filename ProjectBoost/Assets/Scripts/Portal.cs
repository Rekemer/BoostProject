using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(AudioSource))]
public class Portal : MonoBehaviour
{
    [SerializeField] private Portal nextPortal;
    [SerializeField] private float radius;
    private SphereCollider _collider;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip suckInSound;
    [SerializeField] private AudioClip unsuckInSound;
    private bool _isPlayerOverlapping = false;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        _collider.radius = radius;
        _collider.isTrigger = true;
    }

    public void Teleport(Transform obj)
    {
        _isPlayerOverlapping = true;
        obj.position = transform.position;
        var effect = obj.GetComponent<BlackHoleEffect>();
        effect.BlackHolePos = transform.position;
        effect.UnsuckInEffect();
        
    }


   
    private void OnTriggerEnter(Collider other)
    {
        if (_isPlayerOverlapping) return;
        _isPlayerOverlapping = true;
        var effect = other.GetComponent<BlackHoleEffect>();
        if (effect != null)
        {
            effect.BlackHolePos = transform.position;
            StartCoroutine(Waiting(effect));
        }
       

    }

    IEnumerator Waiting( BlackHoleEffect effect)
    {
        yield return effect.SuckingInRoutine();
        _audioSource.clip = suckInSound;
        _audioSource.Play();
        if (effect != null)
        nextPortal.Teleport(effect.transform);
    }
    
    private void OnTriggerExit(Collider other)
    {
        _isPlayerOverlapping = false;
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        var pos = transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos, radius);
        if (nextPortal != null)
        Handles.DrawAAPolyLine(pos, nextPortal.transform.position);
    }

   
#endif
    // Update is called once per frame
    void Update()
    {
    }
}