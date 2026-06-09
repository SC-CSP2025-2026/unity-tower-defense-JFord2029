// CameraEventMaskController.cs
using UnityEngine;

public class CameraEventMaskController : MonoBehaviour
{
    [field: SerializeField]
    public LayerMask EventMask { get; private set; }

    void Awake()
    {
        Camera cam = GetComponent<Camera>();
        cam.eventMask = EventMask;
    }
}