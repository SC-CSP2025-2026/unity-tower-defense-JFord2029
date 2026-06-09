// TileController.cs
using UnityEngine;
using UnityEngine.Events;

public class TileController : MonoBehaviour
{
    [field: SerializeField]
    public bool IsOccupied { get; private set; } = false;

    public UnityEvent<TileController> OnCursorEnter = new UnityEvent<TileController>();
    public UnityEvent<TileController> OnCursorExit = new UnityEvent<TileController>();

    public void NotifyCursorEnter()
    {
        OnCursorEnter.Invoke(this);
    }

    public void NotifyCursorExit()
    {
        OnCursorExit.Invoke(this);
    }
}