// TurretSpawner.cs (updated with public TurretPrefab setter and parent transform)
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TurretPrefab { get; set; } // public setter for button wiring

    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }

    [field: SerializeField]
    public PlayerController Controller { get; private set; }

    void OnEnable()
    {
        Controller.InfoLabel.text = "Select a Tile";
        ListenToTilesIn(TargetGrid);
    }

    void OnDisable()
    {
        Controller.InfoLabel.text = "Click Build to Place a Turret";
        StopListeningToTilesIn(TargetGrid);
    }

    void ListenToTilesIn(GameObject grid)
    {
        if (grid == null) return;

        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorClick.AddListener(SpawnTurret);
            tile.OnCursorEnter.AddListener(ShowInfo);
            tile.OnCursorExit.AddListener(HideInfo);
        }
    }

    void StopListeningToTilesIn(GameObject grid)
    {
        if (grid == null) return;

        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorClick.RemoveListener(SpawnTurret);
            tile.OnCursorEnter.RemoveListener(ShowInfo);
            tile.OnCursorExit.RemoveListener(HideInfo);
        }
    }

    bool CanSpawn(TileController tileController)
    {
        if (tileController.IsOccupied) return false;
        if (Controller.Gold < 50) return false;
        return true;
    }

    void ShowInfo(TileController tileController)
    {
        if (tileController.IsOccupied)
        {
            Controller.InfoLabel.text = "Cannot build here";
        }
        else if (Controller.Gold < 50)
        {
            Controller.InfoLabel.text = "<color=red>Not enough gold";
        }
        else
        {
            Controller.InfoLabel.text = "50 Gold - Place Turret";
        }
    }

    void HideInfo(TileController tileController)
    {
        Controller.InfoLabel.text = "Select a Tile";
    }

    public void SpawnTurret(TileController tileController)
    {
        if (!CanSpawn(tileController)) return;

        // Spawn as child of PlayerController so GoldGenerator can find it via GetComponentInParent
        GameObject turret = Instantiate(TurretPrefab, Controller.transform);
        turret.transform.position = tileController.transform.position;
        tileController.IsOccupied = true;
        Controller.Gold -= 50;

        gameObject.SetActive(false);
    }
}