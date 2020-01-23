using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInputHandler : MonoBehaviour
{
    private IInputManager inputManager;
    private Ball ball;

    private void Start()
    {
        inputManager = MainApp.Instance.InputManager;
        ball = GetComponent<Ball>();

        ball.BallReset += RequestInputReset;

        inputManager.XInputRegistered += OnXInput;
        inputManager.ZInputRegistered += OnZInput;

        RequestInputReset();
    }

    public void RequestInputReset()
    {
        inputManager.ResetInput();
    }

    private void OnXInput(float xValue)
    {
        ball.XAxisAcceleration = xValue;
    }

    private void OnZInput(float yValue)
    {
        ball.ZAxisAcceleration = yValue;
    }

    private void OnDestroy()
    {
        inputManager.XInputRegistered -= OnXInput;
        inputManager.ZInputRegistered -= OnZInput;
    }
}
