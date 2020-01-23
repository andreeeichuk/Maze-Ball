using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    private IGameManager gameManager;

    private void Start()
    {
        gameManager = MainApp.Instance.GameManager;
    }

    public void PlayButton()
    {
        gameManager.StartNewGame();
        gameObject.SetActive(false);
    }
}
