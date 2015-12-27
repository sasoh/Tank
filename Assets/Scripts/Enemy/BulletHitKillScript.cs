using UnityEngine;
using System.Collections;

public class BulletHitKillScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletScript>() != null)
        {
            Destroy(gameObject);
        }
    }
}
