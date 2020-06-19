using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public int[] splashSceneIndexes;
    public SplashTransition splashTransition;
    public float splashViewDuration = 1.5f;
    public bool skipAll = false;

    private void Start()
    {
        StartCoroutine(DisplaySplashSequence());
    }

    public IEnumerator DisplaySplashSequence()
    {
        if (!skipAll)
        {
            for (int i = 0; i < splashSceneIndexes.Length; i++)
            {
                yield return DisplaySplashIndex(splashSceneIndexes[i]);
            }
        }
        yield return AfterSplashes();
    }

    public IEnumerator DisplaySplashIndex(int splashSceneIndex)
    {
        GameEvents.Instance.SplashSequenceBegin();
        yield return SceneManager.LoadSceneAsync(splashSceneIndex, LoadSceneMode.Additive);
        yield return splashTransition.FadeOut();
        yield return new WaitForSeconds(splashViewDuration);
        yield return splashTransition.FadeIn();
        yield return SceneManager.UnloadSceneAsync(splashSceneIndex);
    }

    public IEnumerator AfterSplashes()
    {
        GameEvents.Instance.SplashSequenceEnd();
        yield return splashTransition.FadeOut();
        yield return SceneManager.UnloadSceneAsync((int)Game.SCENE_INDEXES.SPLASH);
    }
}
