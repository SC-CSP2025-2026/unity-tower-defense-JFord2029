// MouseEvents.cs
using UnityEngine;
using UnityEngine.Events;

public class MouseEvents : MonoBehaviour
{
    public UnityEvent OnEnter = new UnityEvent();
    public UnityEvent OnExit = new UnityEvent();
    public UnityEvent OnClick = new UnityEvent();

    void OnMouseEnter()
    {
        OnEnter.Invoke();
    }

    void OnMouseExit()
    {
        OnExit.Invoke();
    }

    void OnMouseUpAsButton()
    {
        OnClick.Invoke();
    }
}