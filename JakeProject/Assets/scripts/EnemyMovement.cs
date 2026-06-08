using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; } = 1f;

    [field: SerializeField]
    public Waypoint Target { get; private set; }

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
        Target = Target.Next; // move to next waypoint
    }
}
}