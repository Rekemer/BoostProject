using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BlackHoleEffect : MonoBehaviour
{
    public Vector3 BlackHolePos;

    [SerializeField] [Range(0, 1)] private float effect;
    public List<Material> _materials = new List<Material>();
    public List<Transform> _children = new List<Transform>();
    [SerializeField] private InterType _typeOfSuckingIn;
    public bool IsPlaying { get; set; }
    [SerializeField] private float TimeToSuckIn;

    void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.GetComponent<MeshRenderer>() != null)
            {
                _children.Add(child);
            }
        }

        foreach (var child in _children)
        {
            if (child.GetComponent<Renderer>() == null) continue;
            var material = child.GetComponent<Renderer>().material;
            if (material != null && !_materials.Contains(material))
            {
                material.SetVector("_blackHole", new Vector4(BlackHolePos.x, BlackHolePos.y, BlackHolePos.z, 0));
                material.SetFloat("_Range", 5f);
                _materials.Add(material);
            }
        }
       
       // Invoke("SuckInEffect", 3f); 
       // Invoke("UnsuckInEffect", 6f); 
    }

    public void SuckInEffect()
    {
        IsPlaying = true;
        StartCoroutine(SuckingInRoutine());
        IsPlaying = false;
    }

    public void UnsuckInEffect()
    {
        IsPlaying = true;
        StartCoroutine(UnuckingInRoutine());
        IsPlaying = false;
    }

    IEnumerator UnuckingInRoutine()
    {
        int limit = 0;
        float elapsedTime = 0f;
        effect = 1;
        while ( effect > 0 + float.Epsilon   )
        {
            if (limit > 1000)
            {
                break;
            }
            elapsedTime += Time.deltaTime;
            limit++;
          //  Debug.Log("LimitOut" + limit);
            float t = Mathf.Clamp(elapsedTime / TimeToSuckIn, 0f, 1f);
            var interpolator = Mathf.Clamp01( Lerp(t, _typeOfSuckingIn));
            Debug.Log("Interpolator" + interpolator);
            foreach (var material in _materials)
            {
                effect =  Mathf.Abs(1 - interpolator) ;
               
                material.SetFloat("_Effect", effect);
            }
            yield return null;
        }

        effect = 0;
    }
    
    IEnumerator SuckingInRoutine()
    {
        int limit = 0;
        float elapsedTime = 0f;
        effect = 0;
        while ( effect < Mathf.Abs( 1 + float.Epsilon) )
        {
            if (limit > 1000)
            {
                break;
            }
            elapsedTime += Time.deltaTime;
            limit++;
            Debug.Log("LimitIn" + limit);
            float t = Mathf.Clamp(elapsedTime / TimeToSuckIn, 0f, 1f);
            effect = Lerp(t, _typeOfSuckingIn);
            foreach (var material in _materials)
            {
                material.SetFloat("_Effect", effect);
            }
            yield return null;
        }

        effect = 1;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(effect);
    }

    float Lerp(float t, InterType interpolation)
    {
        
        switch (interpolation)
        {
            case InterType.Linear:
                break;
            case InterType.EaseOut:
                t = Mathf.Sin(t * Mathf.PI * 0.5f);
                break;
            case InterType.EaseIn:
                t = 1 - Mathf.Cos(t * Mathf.PI * 0.5f);
                break;
            case InterType.SmoothStep:
                t = t * t * (3 - 2 * t);
                break;
            case InterType.SmootherStep:
                t = t * t * t * (t * (t * 6 - 15) + 10);
                break;
            case InterType.Parabola:
                t = t * t*t *4;
                break;
            case InterType.Hyperbolic:
                t = (Mathf.Pow(2.7f,t) - Mathf.Pow(2.7f,-t))/2 * 5;
                break;
        }

        return t;
    }
}

public enum InterType
{
    Linear,
    EaseOut,
    EaseIn,
    SmoothStep,
    SmootherStep,
    Parabola,
    Hyperbolic
}