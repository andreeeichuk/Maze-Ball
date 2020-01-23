using UnityEngine;

public class CommonHole : Hole
{
    [SerializeField] private Renderer holeRenderer = default;
    [SerializeField] private Material runtimeMaskMaterial = default;

    private IGameManager gameManager;

    private void Start()
    {
        gameManager = MainApp.Instance.GameManager;
        holeRenderer.material = runtimeMaskMaterial;
    }

    public override void DoHoleEffect()
    {
        gameManager.Loose();
    }
}
