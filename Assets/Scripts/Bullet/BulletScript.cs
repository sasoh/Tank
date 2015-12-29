using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed = 10.0f;
    public float DestructionDistance = 100.0f;
    public float Damage = 10.0f;
    float DistanceTravelled = 0.0f;
    bool Shot = false;

    void Update()
    {
        if (DistanceTravelled >= DestructionDistance)
        {
            Destroy(gameObject);
            return;
        }

        if (Shot == true)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 position = transform.position;
        position -= transform.up * Speed;
        transform.position = position;

        DistanceTravelled += Speed;
    }

    public void Shoot()
    {
        Shot = true;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}