using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelId = default;
    [SerializeField] private TextMeshProUGUI levelTime = default;

    [SerializeField] private GameObject winWindow = default;
    [SerializeField] private GameObject looseWindow = default;

    [SerializeField] private TextMeshProUGUI winText = default;
    [SerializeField] private Button nextLevelButton = default;

    private IGameManager gameManager;
    private SceneLoader sceneLoader;

    private GameObject activeWindow;

    private void Start()
    {
        gameManager = MainApp.Instance.GameManager;
        sceneLoader = MainApp.Instance.SceneLoader;
        winWindow.SetActive(false);
        looseWindow.SetActive(false);

        gameManager.LevelWon += OnWin;
        gameManager.LevelLost += OnLoose;
        gameManager.CurrentTimeChanged += UpdateTime;
        gameManager.LevelLaunched += UpdateLevelId;
    }

    private void OnWin(bool isLastLevel)
    {
        winWindow.SetActive(true);
        activeWindow = winWindow;
        if(isLastLevel)
        {
            winText.text = "Game Complete!";
            nextLevelButton.interactable = false;
        }
    }

    private void OnLoose()
    {
        looseWindow.SetActive(true);
        activeWindow = looseWindow;
    }

    public void MenuButton()
    {
        sceneLoader.LoadMenuScene();
    }

    public void ReplayButton()
    {
        activeWindow.SetActive(false);
        gameManager.RestartLevel();
    }

    public void NextLevelButton()
    {
        gameManager.ProceedToNextLevel();
    }

    private void UpdateLevelId(int id)
    {
        levelId.text = $"Level {id+1}";
    }

    private void UpdateTime(float value)
    {
        int minutes = (int)value / 60;
        int seconds = (int)value % 60;
        levelTime.text = $"{minutes}:{seconds:D2}";
    }

    private void OnDestroy()
    {
        gameManager.LevelWon -= OnWin;
        gameManager.LevelLost -= OnLoose;
        gameManager.CurrentTimeChanged += UpdateTime;
        gameManager.LevelLaunched += UpdateLevelId;
    }
}
