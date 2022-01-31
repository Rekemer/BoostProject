using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class FinishPoint : MonoBehaviour, ICanEffect, IFinish
{
     private AudioPlayer _audioPlayer;
    [SerializeField] private ParticleSystem _particleSystem;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioPlayer = GetComponent<AudioPlayer>();
    }
    

    public void PlayEffect()
    {
        if (_audioPlayer != null)
        {
            _audioPlayer.Play();
        }

        if (_particleSystem != null)
        {
           _particleSystem.Play();
        }

        _gameManager.IsWin = true;
        _gameManager.IsGameOver = true;

    }
}