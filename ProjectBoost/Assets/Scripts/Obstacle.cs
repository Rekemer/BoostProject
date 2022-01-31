using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioPlayer))]
public class Obstacle : MonoBehaviour, ICanEffect
{
    private AudioPlayer _audioPlayer;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioPlayer = GetComponent<AudioPlayer>();
    }
    

    public void PlayEffect()
    {
        _audioPlayer.Play();
        _gameManager.IsGameOver = true;
    }
}
