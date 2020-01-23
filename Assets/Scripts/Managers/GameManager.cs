using System.Collections;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour, IGameManager
{
    public event Action<bool> LevelWon = delegate { };
    public event Action LevelLost = delegate { };
    public event Action<float> CurrentTimeChanged = delegate { };
    public event Action<int> LevelLaunched = delegate { };

    public int LevelId { get; private set; }
    public float CurrentLevelTime
    {
        get
        {
            return currentLevelTime;
        }
        private set
        {
            currentLevelTime = value;
            CurrentTimeChanged(currentLevelTime);
        }
    }

    private ILevesData levelsData;
    private SceneLoader sceneLoader;
    private Level currentLevel;
    private Coroutine timerCoroutine;

    private float currentLevelTime;

    private void Start()
    {
        sceneLoader = MainApp.Instance.SceneLoader;
        levelsData = MainApp.Instance.LevelsData;
    }   

    public void StartNewGame()
    {
        LevelId = -1;
        ProceedToNextLevel();
    }

    public void ProceedToNextLevel()
    {
        LevelId++;
        string nextLevelName = levelsData.GetSceneNameByLevelId(LevelId);
        sceneLoader.LoadLevelScene(nextLevelName);
    }

    public void SetAndLaunchLevel(Level level)
    {
        currentLevel = level;
        Launch();
        StartCoroutine(WaitForLevelLaunch());
    }
    
    public void RestartLevel()
    {
        currentLevel.ResetLevel();
        Launch();
        LevelLaunched(LevelId);
    }

    public void Win()
    {        
        StopCoroutine(timerCoroutine);
        bool isLastLevel = LevelId == levelsData.LevelCount()-1;
        LevelWon(isLastLevel);
    }

    public void Loose()
    {
        StopCoroutine(timerCoroutine);
        LevelLost();
    }

    private void Launch()
    {
        ResetTimer();
        timerCoroutine = StartCoroutine(Timer());
    }    

    private void ResetTimer()
    {
        CurrentLevelTime = currentLevel.LevelTime;
    }

    private IEnumerator Timer()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);

        while(CurrentLevelTime > 0f)
        {
            yield return wait;
            CurrentLevelTime -= 1f;
        }

        Loose();
    }

    private IEnumerator WaitForLevelLaunch()
    {
        yield return null;
        CurrentTimeChanged(CurrentLevelTime);
        LevelLaunched(LevelId);
    }
}
