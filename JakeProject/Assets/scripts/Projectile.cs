// Projectile.cs
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; } = 2f;

    [field: SerializeField]
    public float Damage { get; private set; } = 1f;

    [field: SerializeField]
    public Transform Target { get; set; }

    void Update()
    {
        // Edge case: destroy projectile if target is gone
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Rotate to face target
        transform.LookAt(Target);

        // Move toward target
        transform.position = Vector3.MoveTowards(
            transform.position,
            Target.position,
            Speed * Time.deltaTime
        );

        // Check if close enough to hit
        if (Vector3.Distance(transform.position, Target.position) < 0.1f)
        {
            Health health = Target.GetComponentInParent<Health>();

            if (health != null)
            {
                health.ApplyHit(this);
            }

            Destroy(gameObject);
        }
    }
}