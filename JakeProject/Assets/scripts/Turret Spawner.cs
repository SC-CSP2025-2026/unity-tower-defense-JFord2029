// TurretSpawner.cs
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TurretPrefab { get; private set; }

    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }

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
            tile.OnCursorClick.AddListener(SpawnTurret);
        }
    }

    void StopListeningToTilesIn(GameObject grid)
    {
        if (grid == null) return;

        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorClick.RemoveListener(SpawnTurret);
        }
    }

    public void SpawnTurret(TileController tileController)
    {
        if (tileController.IsOccupied) return;

        GameObject turret = Instantiate(TurretPrefab);
        turret.transform.position = tileController.transform.position;
        tileController.IsOccupied = true;
    }
}