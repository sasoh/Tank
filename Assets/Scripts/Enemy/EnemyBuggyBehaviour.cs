using UnityEngine;
using System.Collections;

public class EnemyBuggyBehaviour : MonoBehaviour, IDamageable
{
    public float BuggyHealth = 5.0f;
    public float DetonationDistance = 2.0f;
    public GameObject ExplosionPrefab;
    public Transform Player;
    public float Speed = 1.0f;
    private NavMeshAgent _agent;

    private bool _isDead;
    public bool IsDead
    {
        get { return _isDead; }
    }

    public float Health
    {
        get { return BuggyHealth; }
        set { BuggyHealth = value; }
    }

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        Debug.Assert(_agent != null);
        _agent.speed = Speed;
        _isDead = false;
    }

    void Update()
    {
        if (Physics.Linecast(transform.position, Player.position) == false)
        {
            // set destination if line of sight exists
            _agent.SetDestination(Player.position);

            Debug.DrawLine(transform.position, Player.position, Color.red);
        }

        if (Vector3.Distance(transform.position, Player.position) <= DetonationDistance)
        {
            Destruct();
        }
    }

    public void Hit(float damage)
    {
        Health -= damage;

        if (Health <= 0.0f)
        {
            Destruct();
        }
    }

    public void Destruct()
    {
        if (_isDead == false)
        {
            _isDead = true;

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
