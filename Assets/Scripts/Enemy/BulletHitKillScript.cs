using UnityEngine;

public class BulletHitKillScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        BulletScript bullet = other.gameObject.GetComponent<BulletScript>();
        if (bullet != null)
        {
            IDamageable hitTarget = GetComponent<IDamageable>();
            if (hitTarget != null)
            {
                hitTarget.Hit(bullet.Damage);
            }
        }
    }
}
