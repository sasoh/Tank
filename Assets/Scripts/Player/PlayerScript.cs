using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour, IDamageable
{
    public float PlayerHealth = 20.0f;
    public float Health
    {
        get { return PlayerHealth; }
        set { PlayerHealth = value; }
    }

    private bool _isDead;
    public bool IsDead
    {
        get { return _isDead; }
    }

    public void Hit(float damage)
    {
        Health -= damage;

        if (Health <= 0.0f)
        {
            Debug.Log("Player dead.");
        }
    }
}
