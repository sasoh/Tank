using UnityEngine;

public class BulletHitKillScript : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    bool IsDead = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletScript>() != null)
        {
            if (IsDead == false)
            {
                IsDead = true;

                if (ExplosionPrefab != null)
                {
                    Vector3 position = transform.position;
                    position.y -= 0.25f;

                    GameObject explosion = Instantiate(ExplosionPrefab);
                    explosion.transform.position = position;
                    explosion.transform.rotation = Quaternion.identity;
                }

                Destroy(gameObject);
            }
        }
    }
}
