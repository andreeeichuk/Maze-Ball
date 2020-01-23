using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
    public event Action LevelLoaded = delegate { };
    public event Action MenuLoaded = delegate { };

    private GameObject loadingCanvasContent;

    public void SetLoadingCanvas(GameObject canvasContent)
    {
        loadingCanvasContent = canvasContent;
    }

    public void LoadLevelScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName, SceneType.Level));
    }

    public void LoadMenuScene()
    {
        StartCoroutine(LoadSceneAsync("Scene_Menu", SceneType.Menu));
    }

    private IEnumerator LoadSceneAsync(string sceneName, SceneType sceneType)
    {
        loadingCanvasContent.SetActive(true);

        // fake loading time if level loads too quickly;
        yield return new WaitForSeconds(0.5f);

        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneName);

        while (sceneLoading.isDone)
        {
            yield return null;
        }

        switch(sceneType)
        {
            case SceneType.Menu:
                MenuLoaded();
                break;
            case SceneType.Level:
                LevelLoaded();
                break;
        }
    }
}
