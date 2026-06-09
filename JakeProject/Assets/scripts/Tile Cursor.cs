// TileCursor.cs
using UnityEngine;

public class TileCursor : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }

    [field: SerializeField]
    public GameObject Model { get; private set; }

    void OnEnable()
    {
        ListenToTilesIn(TargetGrid);
    }

    void OnDisable()
    {
        StopListeningToTilesIn(TargetGrid);
    }

    void ListenToTilesIn(GameObject grid)
    {
        if (grid == null) return;

        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.AddListener(HandleTileEntered);
            tile.OnCursorExit.AddListener(HandleTileExited);
        }
    }

    void StopListeningToTilesIn(GameObject grid)
    {
        if (grid == null) return;

        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.RemoveListener(HandleTileEntered);
            tile.OnCursorExit.RemoveListener(HandleTileExited);
        }
    }

    public void HandleTileEntered(TileController tile)
    {
        transform.position = tile.transform.position;

        if (Model != null)
            Model.SetActive(true);
    }

    public void HandleTileExited(TileController tile)
    {
        if (Model != null)
            Model.SetActive(false);
    }
}