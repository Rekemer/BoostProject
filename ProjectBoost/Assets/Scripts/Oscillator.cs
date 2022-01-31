using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private Vector3 _startingPos;
    [SerializeField] private Vector3 _movementVector;
    [SerializeField] private float time = 2f;
    [SerializeField] private float period = 2f;
    
    [SerializeField] private iTween.EaseType _easeType;
    // Start is called before the first frame update
    void Start()
    {
       _startingPos =  transform.position;
      // iTween.MoveTo(gameObject, iTween.Hash( "position", transform.position + _movementVector, "looptype", iTween.LoopType.pingPong,"time", time, "easetype", _easeType));
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) return;
        const float tau = Mathf.PI * 2f;
        float cycles = Time.time / period;
        float sinValue = Mathf.Sin(cycles * tau);
        float factor = (sinValue+1)/2f;
        Vector3 offset = factor * _movementVector;
        transform.position = _startingPos + offset;
    }
}
