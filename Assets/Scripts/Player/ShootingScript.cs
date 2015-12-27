using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
    public BulletScript BulletPrefab;
    public float ShootInterval = 0.2f;
    float LastShotTime;

    void Update()
    {
        LastShotTime += Time.deltaTime;

        ProcessInput();
    }

    void ProcessInput()
    {
        InputData input = InputManager.Instance.GetInput();

        if (input.Shooting == true && LastShotTime >= ShootInterval)
        {
            LastShotTime = 0.0f;

            Shoot();
        }
    }

    // spawn & launch bullet forward
    void Shoot()
    {
        Debug.Assert(BulletPrefab != null);

        BulletScript bullet = Instantiate(BulletPrefab);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        bullet.Shoot();
    }
}
