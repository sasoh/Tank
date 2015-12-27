using UnityEngine;
using System.Collections;

public enum ControlOrientation
{
    None,
    Movement,
    Looking
}

public class PlayerOrientScript : MonoBehaviour
{
    public ControlOrientation Orientation = ControlOrientation.None;
    public float RotationSpeed = 1.0f;
    Vector3 LastDirection = new Vector3();

    void Awake()
    {
        LastDirection = transform.forward;
    }

    void Update()
    {
        InputData input = InputManager.Instance.GetInput();

        // orient
        Vector3 direction = new Vector3(input.LookHorizontal, 0.0f, input.LookVertical);
        if (Orientation == ControlOrientation.Movement)
        {
            direction.x = input.Horizontal;
            direction.z = input.Vertical;
        }

        // for any significant direction change
        if (Vector3.SqrMagnitude(direction) >= 0.01f)
        {
            direction.Normalize();
            LastDirection = direction;
        }

        Quaternion targetRotation = Quaternion.LookRotation(LastDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }
}
