using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour
{
    public float TimeToDestruction = 1.0f;
    float CurrentTime = 0.0f;

    void Update()
    {
        CurrentTime += Time.deltaTime;
        
        if (CurrentTime >= TimeToDestruction)
        {
            Destroy(gameObject);
        }
    }
}
