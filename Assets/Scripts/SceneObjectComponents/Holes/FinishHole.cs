public class FinishHole : Hole
{
    private IGameManager gameManager;

    private void Start()
    {
        gameManager = MainApp.Instance.GameManager;
    }

    public override void DoHoleEffect()
    {
        gameManager.Win();
    }
}
