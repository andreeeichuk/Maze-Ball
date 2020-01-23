using System;
using UnityEngine;

public class MouseInputManager : MonoBehaviour, IInputManager
{
    public event Action<float> XInputRegistered;
    public event Action<float> ZInputRegistered;

    public float XInput { get; private set; }
    public float ZInput { get; private set; }

    public float Sensitivity { get; set; } = 0.1f;

    private void Update()
    {
        RegisterInput();

        RaiseEvents();
    }

    public void RegisterInput()
    {
        XInput += Input.GetAxis("Mouse X") * Sensitivity;
        ZInput += Input.GetAxis("Mouse Y") * Sensitivity;

        XInput = Mathf.Clamp(XInput, -1f, 1f);
        ZInput = Mathf.Clamp(ZInput, -1f, 1f);
    }

    public void RaiseEvents()
    {
        XInputRegistered?.Invoke(XInput);
        ZInputRegistered?.Invoke(ZInput);        
    }

    public void ResetInput()
    {
        XInput = 0f;
        ZInput = 0f;
    }
}
