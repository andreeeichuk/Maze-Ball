using System;

public interface IGameManager
{
    // bool for isLastLevel
    event Action<bool> LevelWon;
    event Action LevelLost;
    event Action<float> CurrentTimeChanged;
    // necessary for UI;
    event Action<int> LevelLaunched;

    void StartNewGame();
    void ProceedToNextLevel();
    void SetAndLaunchLevel(Level level);
    void RestartLevel();
    void Win();
    void Loose();
}
