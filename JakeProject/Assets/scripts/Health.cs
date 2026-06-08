// Health.cs
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField]
    public float BaseHealth { get; private set; } = 3f;

    [field: SerializeField]
    public float Damage { get; private set; } = 0f;

    public void ApplyHit(Projectile projectile)
    {
        Damage += projectile.Damage;

        if (Damage >= BaseHealth)
        {
            Destroy(gameObject);
        }
    }
}