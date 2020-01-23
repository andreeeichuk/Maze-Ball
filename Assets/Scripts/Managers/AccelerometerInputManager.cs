using System;
using UnityEngine;

public class AccelerometerInputManager : MonoBehaviour, IInputManager
{
    public float XInput { get; private set; }
    public float ZInput { get; private set; }

    public event Action<float> XInputRegistered;
    public event Action<float> ZInputRegistered;

    public float Sensitivity { get; set; } = 5f;

    private void Update()
    {
        RegisterInput();

        RaiseEvents();
    }

    public void RaiseEvents()
    {
        XInputRegistered?.Invoke(XInput);
        ZInputRegistered?.Invoke(ZInput);
    }

    public void RegisterInput()
    {
        XInput = Input.acceleration.x * Sensitivity;
        ZInput = Input.acceleration.y * Sensitivity;

        XInput = Mathf.Clamp(XInput, -1f, 1f);
        ZInput = Mathf.Clamp(ZInput, -1f, 1f);
    }

    public void ResetInput()
    {
        XInput = 0f;
        ZInput = 0f;
    }
}
