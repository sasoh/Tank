public interface IDamageable
{
    void Hit(float damage);
    float Health
    {
        get;
        set;
    }

    bool IsDead
    {
        get;
    }
}