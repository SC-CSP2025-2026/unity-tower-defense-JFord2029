using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; } = 1f;

    [field: SerializeField]
    public Waypoint Target { get; private set; }

    void Start()
    {
        if (Target != null)
        {
            transform.LookAt(Target.transform);
        }
    }

    void Update()
    {
        if (Target == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            Target.transform.position,
            Speed * Time.deltaTime
        );

        if (transform.position == Target.transform.position)
        {
            SetTarget(Target.Next);
        }
    }

    void SetTarget(Waypoint nextWaypoint)
    {
        Target = nextWaypoint;

        if (Target != null)
        {
            transform.LookAt(Target.transform);
        }
    }
}