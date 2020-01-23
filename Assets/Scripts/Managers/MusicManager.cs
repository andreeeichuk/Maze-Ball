using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour, IMusicManager
{
    private IMusicData musicData;
    private SceneLoader sceneLoader;
    private IGameManager gameManager;
    private AudioSource source;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        ConfigureAudioSource();
        musicData = MainApp.Instance.MusicData;
        sceneLoader = MainApp.Instance.SceneLoader;
        gameManager = MainApp.Instance.GameManager;
        gameManager.LevelLost += PlayLoose;
        gameManager.LevelWon += PlayWin;
        gameManager.LevelLaunched += PlayLevelMusic;
        sceneLoader.MenuLoaded += PlayMenuMusic;        
        PlayMenuMusic();
    }

    public void ConfigureAudioSource()
    {
        source.playOnAwake = false;
        source.loop = true;
    }

    public void PlayLevelMusic(int levelId)
    {
        // Тут для годиться потрібно було уже передавати складнішу структуру, яка б містила
        // дані про те, звідки має починатись кліп, а не тільки сам клім, якщо він добре не
        // обрізаний
        source.clip = musicData.LevelMusic;
        source.loop = true;
        source.time = 7f;
        source.Play();
    }

    public void PlayMenuMusic()
    {
        source.loop = true;
        source.clip = musicData.MenuMusic;
        source.time = 0f;
        source.Play();
    }

    public void PlayWin(bool isLastLevel)
    {
        source.loop = false;
        source.clip = musicData.WinMusic;
        source.time = 0f;
        source.Play();
    }

    public void PlayLoose()
    {
        source.loop = false;
        source.clip = musicData.LooseMusic;
        source.time = 0f;
        source.Play();
    }    
}
