using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }
    public GameState gameState;
    public GameEvents gameEvents;
    public Map map;

    public enum SCENE_INDEXES
    {
        MAIN = 0,
        SPLASH = 1,
        MJUKMARA = 2,
        COOL_STUFF = 3,
        OTHER_STUFF = 4,
        INGAME = 5,
        MAIN_MENU = 6,
        LOADING = 7,
    }

    private void OnEnable()
    {
        gameEvents.OnSplashSequenceEnd += OnSplashSequenceEnd;
        gameEvents.OnNewGame += OnNewGame;
        gameEvents.OnExitToMainMenu += OnExitToMainMenu;
    }

    private void OnDisable()
    {
        gameEvents.OnSplashSequenceEnd -= OnSplashSequenceEnd;
        gameEvents.OnNewGame -= OnNewGame;
        gameEvents.OnExitToMainMenu -= OnExitToMainMenu;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        gameState = new GameState();
        gameState.mapData = new MapData();
        gameState.mapData.width = 16;
        gameState.mapData.length = 16;
    }

    private void Start()
    {

        OnGameStart();
    }

    private IEnumerator LoadSceneAsyncWithLoadingScreen(int unloadSceneIndex, int loadSceneIndex)
    {
        yield return SceneManager.LoadSceneAsync((int)SCENE_INDEXES.LOADING, LoadSceneMode.Additive);
        yield return SceneManager.UnloadSceneAsync(unloadSceneIndex);
        yield return SceneManager.LoadSceneAsync(loadSceneIndex, LoadSceneMode.Additive);
        yield return new WaitForSeconds(.25f);
        yield return SceneManager.UnloadSceneAsync((int)SCENE_INDEXES.LOADING);
    }

    private void OnGameStart()
    {
        SceneManager.LoadScene((int)SCENE_INDEXES.MAIN);
        SceneManager.LoadSceneAsync((int)SCENE_INDEXES.SPLASH, LoadSceneMode.Additive);
    }

    private void OnSplashSequenceEnd()
    {
        SceneManager.LoadSceneAsync((int)SCENE_INDEXES.MAIN_MENU, LoadSceneMode.Additive);
    }

    private void OnNewGame()
    {
        StartCoroutine(LoadSceneAsyncWithLoadingScreen((int)SCENE_INDEXES.MAIN_MENU, (int)SCENE_INDEXES.INGAME));
    }

    private void OnExitToMainMenu()
    {
        StartCoroutine(LoadSceneAsyncWithLoadingScreen((int)SCENE_INDEXES.INGAME, (int)SCENE_INDEXES.MAIN_MENU));
    }

    public void OnSaveGame()
    {
        GameState.Save("first", gameState);
    }

    public void OnLoadGame()
    {
        gameState = (GameState)GameState.Load("first");
    }

    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Mouse.current.position.ReadValue();
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
