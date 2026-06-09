// TileController.cs (updated)
using UnityEngine;
using UnityEngine.Events;

public class TileController : MonoBehaviour
{
    [field: SerializeField]
    public bool IsOccupied { get; set; } = false; // changed to public setter

    public UnityEvent<TileController> OnCursorEnter = new UnityEvent<TileController>();
    public UnityEvent<TileController> OnCursorExit = new UnityEvent<TileController>();
    public UnityEvent<TileController> OnCursorClick = new UnityEvent<TileController>();

    public void NotifyCursorEnter()
    {
        OnCursorEnter.Invoke(this);
    }

    public void NotifyCursorExit()
    {
        OnCursorExit.Invoke(this);
    }

    public void NotifyCursorClicked()
    {
        OnCursorClick.Invoke(this);
    }
}