using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool IsGameOver;
    private bool IsWin;
    // Start is called before the first frame update
    IEnumerator GameLoop()
    {
        yield return StartCoroutine("StartRoutine");
        yield return StartCoroutine("PlayRoutine");
        yield return StartCoroutine("EndRoutine");
        yield return null;
    }

  


    void Start()
    {
        StartCoroutine(GameLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator StartRoutine()
    {
        Debug.Log("start");
        yield return null;
    }

    private IEnumerator PlayRoutine()
    {
        Debug.Log("play");
        yield return null;
    }

    private IEnumerator EndRoutine()
    { 
        Debug.Log("end");
        yield return null;
    }
}
