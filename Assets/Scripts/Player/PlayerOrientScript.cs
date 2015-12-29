using UnityEngine;

public enum ControlOrientation
{
    None,
    Movement,
    Looking
}

public class PlayerOrientScript : MonoBehaviour
{
    public ControlOrientation Orientation = ControlOrientation.None;
    public float TrackSightRadius = 1.0f;
    public float RotationSpeed = 1.0f;
    Quaternion TargetRotation;

    void Awake()
    {
        TargetRotation = transform.rotation;
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
        if (Vector3.SqrMagnitude(direction) >= TrackSightRadius * TrackSightRadius)
        {
            TargetRotation = Quaternion.LookRotation(direction);
        }
        
        if (Quaternion.Angle(transform.rotation, TargetRotation) < TrackSightRadius)
        {
            // reached
            transform.rotation = TargetRotation;
            TargetRotation = transform.rotation;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, RotationSpeed * Time.deltaTime);
    }
}
