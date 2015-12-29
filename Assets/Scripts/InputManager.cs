using UnityEngine;

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
        Vector2 moving = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 looking = new Vector2(Input.GetAxis("Pad X"), Input.GetAxis("Pad Y"));

        InputData newInput = new InputData
        {
            Movement = moving,
            Looking = looking,
            Shooting = Input.GetButton("Fire1")
        };

        LastInput = newInput;
    }
}
