using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.Instance.OnNewGame += OnNewGame;
    }

    private void OnDisable()
    {
        GameEvents.Instance.OnNewGame -= OnNewGame;
    }

    public void NewGame()
    {
        GameEvents.Instance.NewGame();
    }

    private void OnNewGame()
    {
        SceneManager.UnloadSceneAsync((int)Game.SCENE_INDEXES.MAIN_MENU);
    }
}
