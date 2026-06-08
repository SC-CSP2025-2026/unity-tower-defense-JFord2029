// TurretTarget.cs
using UnityEngine;

public class TurretTarget : MonoBehaviour
{
    [field: SerializeField]
    public AreaOfEngagement AreaOfEngagement { get; private set; }

    [field: SerializeField]
    public GameObject Model { get; private set; }

    void Update()
    {
        if (AreaOfEngagement == null) return;
        if (Model == null) return;
        if (AreaOfEngagement.Targets.Count == 0) return;

        // Remove any null targets (in case an enemy was destroyed)
        AreaOfEngagement.Targets.RemoveAll(t => t == null);

        if (AreaOfEngagement.Targets.Count == 0) return;

        Vector3 targetPosition = AreaOfEngagement.Targets[0].position;

        // Lock Y axis so turret only rotates horizontally, never tilts up or down
        targetPosition.y = Model.transform.position.y;

        Model.transform.LookAt(targetPosition);
    }
}