using UnityEngine;

public class LoadingUIController : MonoBehaviour
{
    [SerializeField] private GameObject content = default;

    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = MainApp.Instance.SceneLoader;
        sceneLoader.SetLoadingCanvas(content);
    }

    private void OnDestroy()
    {
        sceneLoader.SetLoadingCanvas(null);
    }
}
