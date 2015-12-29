using UnityEngine;

public struct InputData
{
    public float Horizontal;
    public float Vertical;
    public float LookHorizontal;
    public float LookVertical;
    public bool Shooting;
}

/// <summary>
/// Returns input from last FixedUpdate.
/// </summary>
public class InputManager : Singleton<InputManager>
{
    InputData LastInput;

    protected InputManager()
    {
        // hidden constructor
    }

    public InputData GetInput()
    {
        return LastInput;
    }

    void FixedUpdate()
    {
        InputData newInput = new InputData
        {
            Horizontal = Input.GetAxis("Horizontal"),
            Vertical = Input.GetAxis("Vertical"),
            LookHorizontal = Input.GetAxis("Pad X"),
            LookVertical = Input.GetAxis("Pad Y"),
            Shooting = Input.GetButton("Fire1")
        };

        LastInput = newInput;
    }
}
