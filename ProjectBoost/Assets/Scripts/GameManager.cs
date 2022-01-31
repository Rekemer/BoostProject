using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool IsWin { get; set; }
    public bool IsGameOver { get; set; } 
    [SerializeField] private ScreenFader _screenFader;
    private Movement _movement;
    [SerializeField] private RectXformMover EndMessageWindow;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private RectXformMover StartMessageWindow;

    public bool IsReadyToBegin { get; set; }
    // Start is called before the first frame update
    private void Awake()
    {
        _movement = FindObjectOfType<Movement>();
    }

    void Start()
    {
        _movement.CanMove = false;
        _screenFader.gameObject.SetActive(true);
        EndMessageWindow.gameObject.SetActive(false);
        StartCoroutine(GameLoop());
    }


    
   
  
    
    IEnumerator GameLoop()
    {
        yield return StartCoroutine("StartRoutine");
        yield return StartCoroutine("PlayRoutine");
        yield return StartCoroutine("EndRoutine");
        yield return null;
    }

  
    private IEnumerator StartRoutine()
    {
        Debug.Log("start");
        if (_screenFader != null)
        {
            _screenFader.FadeOff();
        }
        yield return new WaitForSeconds(1f);
        ShowStartUI();
        while (!IsReadyToBegin)
        {
            yield return null;
        }

        _movement.CanMove = true;
        CloseStartUI();

    }

   

    private IEnumerator PlayRoutine()
    {
        Debug.Log("play");
        while (!IsGameOver)
        {
            yield return null;
        }
       
    }

    private IEnumerator EndRoutine()
    {
        Debug.Log("end");
        if (IsGameOver == true && IsWin == true)
        {
            ShowVictoryUI();
        }
        else
        {
            ShowLoseUI();
        }
        yield return null;
    }

    #region Loading

    private IEnumerator LoadLevel(int levelIndex)
    {
        _screenFader.FadeOn();
        yield return new WaitForSeconds(1.5f);
        if (levelIndex >= 0 && SceneManager.sceneCountInBuildSettings > levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            Debug.LogWarning("invalid scene index");
        }

        yield return null;
    }

    public void ReloadLevel()
    {
       StartCoroutine( LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    public void LoadNextLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var nextSceneIndex = ++currentSceneIndex;
        var totalSceneCount = SceneManager.sceneCountInBuildSettings;
        StartCoroutine(LoadLevel(nextSceneIndex % totalSceneCount));
    }

    #endregion
   

    #region UI

    public void ShowStartUI()
    {
        StartMessageWindow.gameObject.SetActive(true);
        StartMessageWindow.MoveOn();
    }
    private void CloseStartUI()
    {
        StartCoroutine(CloseStartUIRoutine());
    }

    IEnumerator CloseStartUIRoutine()
    {
        StartMessageWindow.MoveOff();
        while (StartMessageWindow.IsMoving)
        {
            yield return null;
        }
        StartMessageWindow.gameObject.SetActive(false);
    }
    
    public void ShowLoseUI()
    {
        _textMeshPro.text = "Rocket made boom!";
        EndMessageWindow.gameObject.SetActive(true);
        EndMessageWindow.MoveOn();
    }

    public void ShowVictoryUI()
    {
        _textMeshPro.text = "Rocket won!";
        EndMessageWindow.gameObject.SetActive(true);
        EndMessageWindow.MoveOn();
    }

    #endregion
   
}
