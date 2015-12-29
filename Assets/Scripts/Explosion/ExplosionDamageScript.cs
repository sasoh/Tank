using UnityEngine;
using System.Collections;

public class ExplosionDamageScript : MonoBehaviour
{
    public float DetonationDamage = 10.0f;

    void OnTriggerEnter(Collider other)
    {
        IDamageable hitTarget = other.gameObject.GetComponent<IDamageable>();
        if (hitTarget != null)
        {
            hitTarget.Hit(DetonationDamage);
        }
    }
}