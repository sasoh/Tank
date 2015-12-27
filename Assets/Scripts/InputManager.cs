using UnityEngine;
using System.Collections;

public struct InputData
{
    public float Horizontal;
    public float Vertical;
    public float LookHorizontal;
    public float LookVertical;
    public bool Shooting;
    public bool FromPad;
}

/// <summary>
/// Returns input from last FixedUpdate.
/// </summary>
public class InputManager : Singleton<InputManager>
{
    float DeadZone = 0.1f;
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
        InputData newInput = new InputData();

        newInput.Horizontal = Input.GetAxis("Horizontal");
        newInput.Vertical = Input.GetAxis("Vertical");

        newInput.LookHorizontal = Input.GetAxis("Pad X");
        newInput.LookVertical = Input.GetAxis("Pad Y");
        
        newInput.Shooting = Input.GetButton("Fire1");

        LastInput = newInput;
    }
}
