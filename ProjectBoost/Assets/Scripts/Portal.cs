using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Portal : MonoBehaviour
{
    [SerializeField] private Portal nextPortal;
    [SerializeField] private float radius;
    private SphereCollider _collider;
    private bool _isPlayerOverlapping = false;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
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
        if (_isPlayerOverlapping == true) return;
        if (nextPortal != null)
        {
            var effect = other.GetComponent<BlackHoleEffect>();
            effect.BlackHolePos = transform.position;
            if (!effect.IsPlaying)
            {
                effect.SuckInEffect();
                WaitForEffect(effect);
            }
        }
    }

    private void WaitForEffect(BlackHoleEffect effect)
    {
        StartCoroutine(WaitForEffectRoutine(effect));
    }

    IEnumerator WaitForEffectRoutine(BlackHoleEffect effect)
    {
        var limit = 0;
        while (effect.IsPlaying)
        {
            //Debug.Log(effect.IsPlaying);
            limit++;
            if (limit > 1000)
            {
                break;
            }

            yield return null;
        }

        nextPortal.Teleport(effect.transform);
        _isPlayerOverlapping = true;
    }

    private void PlayEffect()
    {
        StartCoroutine(PlayEffectRoutine());
    }

    private IEnumerator PlayEffectRoutine()
    {
        float t = 0;
        while (t != 1)
        {
        }

        yield return null;
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
        Handles.DrawAAPolyLine(pos, nextPortal.transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1f);
    }
#endif
    // Update is called once per frame
    void Update()
    {
    }
}