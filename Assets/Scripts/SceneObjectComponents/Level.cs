using UnityEngine;
using System;

public class Level : MonoBehaviour
{
    public float LevelTime => levelTime;

    [SerializeField] Ball ball = default;
    [SerializeField] BoardBottom boardBottom = default;
    [SerializeField] BoardBottomBottom boardBottomBottom = default;
    [SerializeField] Transform startPoint = default;
    [SerializeField] FakeCollider fakeCollider = default;
    [SerializeField] float levelTime = default;


    private IGameManager gameManager;

    private Action currentHoleEffect;

    private void Start()
    {
        gameManager = MainApp.Instance.GameManager;
        gameManager.SetAndLaunchLevel(this);
        Hole.BallInHole += FakeBallFalling;
        boardBottomBottom.FallEnded += OnFallEnd;
        gameManager.LevelLost += OnLoose;
    }

    public void ResetLevel()
    {
        ball.Move(startPoint.position);
        ball.ResetBall();
        boardBottom.ActivateCollider();
        fakeCollider.MoveDown();
    }

    private void FakeBallFalling(Vector3 holePosition, Action holeEffect)
    {
        boardBottom.DeactivateCollider();
        Vector3 lastBallPosition = new Vector3(ball.CurrentPosition.x, 0f, ball.CurrentPosition.z);
        fakeCollider.SetPositionAndRotation(lastBallPosition, holePosition);
        ball.ContinueFall(holePosition);
        currentHoleEffect = holeEffect;
    }

    private void OnFallEnd()
    {
        currentHoleEffect();
    }
    
    private void OnLoose()
    {
        // freeze ball, e.g. when time is up
        ball.FreezeBall();
    }

    private void OnDestroy()
    {
        Hole.BallInHole -= FakeBallFalling;
        gameManager.LevelLost -= OnLoose;
    }
}
