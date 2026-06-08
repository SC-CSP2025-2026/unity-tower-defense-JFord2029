using UnityEditor;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [field: SerializeField]
    public Waypoint Next { get; private set; }

    void OnDrawGizmos()
    {
        if (Next == null) return; // null check to prevent crash
        
        Handles.color = Color.red; // fixed: was "colors"
        Handles.DrawLine(transform.position, Next.transform.position, 3f);
    }
}