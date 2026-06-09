// Health.cs (updated)
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field: SerializeField]
    public float BaseHealth { get; private set; } = 3f;

    [field: SerializeField]
    public float Damage { get; private set; } = 0f;

    public UnityEvent<Health> OnDeath { get; private set; } = new UnityEvent<Health>();

    public void ApplyHit(Projectile projectile)
    {
        Damage += projectile.Damage;

        if (Damage >= BaseHealth)
        {
            OnDeath.Invoke(this);
            Destroy(gameObject);
        }
    }
}