using UnityEngine;

public class MainApp : MonoBehaviour
{
    public static MainApp Instance { get; private set; }

    public SceneLoader SceneLoader { get; private set; }
    public IGameManager GameManager { get; private set; }
    public IInputManager InputManager { get; private set; }
    public IMusicManager MusicManager { get; private set; }
    public ILevesData LevelsData { get; private set; }
    public IMusicData MusicData { get; private set; }

    [SerializeField] private LevelsData levelDataSO = default;
    [SerializeField] private MusicData musicDataSO = default;

    public void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);                        
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LevelsData = levelDataSO;
            MusicData = musicDataSO;

            SceneLoader = gameObject.AddComponent<SceneLoader>();
            GameManager = gameObject.AddComponent<GameManager>();
#if UNITY_EDITOR
            InputManager = gameObject.AddComponent<MouseInputManager>();
#elif UNITY_ANDROID
        InputManager = gameObject.AddComponent<AccelerometerInputManager>();
#endif
            MusicManager = gameObject.AddComponent<MusicManager>();
        }       
    }    
}
