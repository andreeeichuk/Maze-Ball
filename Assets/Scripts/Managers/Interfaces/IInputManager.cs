using System;

public interface IInputManager
{
    event Action<float> XInputRegistered;
    event Action<float> ZInputRegistered;

    float XInput { get; }
    float ZInput { get; }

    float Sensitivity { get; set; }

    void RegisterInput();
    void RaiseEvents();

    void ResetInput();
}
