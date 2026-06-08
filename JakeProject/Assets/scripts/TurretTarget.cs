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

        AreaOfEngagement.Targets.RemoveAll(t => t == null);
        if (AreaOfEngagement.Targets.Count == 0) return;

        Vector3 targetPosition = AreaOfEngagement.Targets[0].transform.position;
        targetPosition.y = Model.transform.position.y;

        Model.transform.LookAt(targetPosition);
    }
}