using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance { get; private set; }

    public event Action OnSplashSequenceBegin;
    public event Action OnSplashSequenceEnd;
    public event Action OnSplashBegin;
    public event Action OnSplashEnd;
    public event Action OnNewGame;
    public event Action OnExitToMainMenu;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    public void SplashSequenceBegin() => OnSplashSequenceBegin?.Invoke();

    public void SplashSequenceEnd() => OnSplashSequenceEnd?.Invoke();

    public void SplashBegin() => OnSplashBegin?.Invoke();

    public void SplashEnd() => OnSplashEnd?.Invoke();

    public void NewGame() => OnNewGame?.Invoke();

    public void ExitToMainMenu() => OnExitToMainMenu?.Invoke();
}
