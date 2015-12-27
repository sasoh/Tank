using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // Bullet object for instantiating on shooting.
    public BulletScript BulletPrefab;

    // A bullet is spawned for each shooting point defined here. No shooting points mean no shooting.
    public Transform[] Barrels;

    // Time between shots (in seconds).
    public float ShootInterval = 0.2f;

    // If true, shooting immediately from all shooting points, if false - from next unfired.
    public bool AlternateFire = false;

    // Current alternate shooting barrel;
    int CurrentShooterIndex = 0;

    // Counts time from last shot.
    float LastShotTime;

    void Awake()
    {
        Debug.Assert(Barrels.Length > 0);
    }

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

            Shoot(Barrels, BulletPrefab);
        }
    }

    // Shoots from barrels.
    void Shoot(Transform[] points, BulletScript prefab)
    {
        if (AlternateFire == false)
        {
            foreach (Transform point in points)
            {
                ShootFromPoint(point, prefab);
            }
        }
        else
        {
            ShootFromPoint(points[CurrentShooterIndex], prefab);

            CurrentShooterIndex++;
            if (CurrentShooterIndex >= Barrels.Length)
            {
                CurrentShooterIndex = 0;
            }
        }
    }

    // Spawns and launches a bullet.
    void ShootFromPoint(Transform point, BulletScript prefab)
    {
        Debug.Assert(point);
        Debug.Assert(prefab != null);

        BulletScript bullet = Instantiate(prefab);
        bullet.transform.position = point.position;
        bullet.transform.rotation = transform.rotation;

        bullet.Shoot();
    }
}
