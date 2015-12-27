using UnityEngine;
using System.Collections;

public class KeepDistanceScript : MonoBehaviour
{
    public Transform TrackingPoint;

    // Initial offset between GameObject position & target point position.
    Vector3 InitialOffset;

    void Awake()
    {
        Debug.Assert(TrackingPoint, "Camera has nothing to track.");
        InitialOffset = TrackingPoint.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = TrackingPoint.transform.position - InitialOffset;
    }
}
