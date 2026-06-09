using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [field: SerializeField]
    public Waypoint StartTarget { get; private set; }

    [field: SerializeField]
    public EnemyMovement Enemy { get; private set; }

    [field: SerializeField]
    public float Delay { get; private set; } = 1f;

    [field: SerializeField]
    public int SpawnsRemaining { get; private set; } = 5;

    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 0f, Delay);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Spawn()
    {
        EnemyMovement enemy = Instantiate(Enemy, transform.position, transform.rotation);
        enemy.Target = StartTarget;

        SpawnsRemaining--;

        if (SpawnsRemaining <= 0)
        {
            CancelInvoke();
        }
    }
}