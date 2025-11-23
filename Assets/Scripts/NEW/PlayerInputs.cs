using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private new_Map map;
    [SerializeField] private Inventory_Manager inventory;
    [SerializeField] private VisualMap visual;
    [SerializeField] private CameraFollower cam;

    [ContextMenu("Move Down")]
    public void OnDown()
    {
        if (!inventory.InventoryActive)
            map.MoveDown();
        UpdateVisuals();
    }
    [ContextMenu("Move Up")]
    public void OnUp()
    {
        if (!inventory.InventoryActive)
            map.MoveUp();
        UpdateVisuals();
    }
    [ContextMenu("Move Left")]
    public void OnLeft()
    {
        if(!inventory.InventoryActive)
            map.MoveLeft();
        UpdateVisuals();
    }
    [ContextMenu("Move Right")]
    public void OnRight()
    {
        if (!inventory.InventoryActive)
            map.MoveRight();
        UpdateVisuals();
    }

    public void OnStartButton()
    {
        inventory.PanelActivation();
    }
    public void OnPlus()
    {
        cam.ZoomUp();
    }
    public void OnMinus()
    {
        cam.ZoomDown();
    }

    public void UpdateVisuals()
    {
        Player p = map.p;
        int x = map.p.PosX;
        int y = map.p.PosY;
        Items i = map.GetTile(x, y).item;

        visual.UpdatePlayer(p);
        visual.UpdateItem(i, x, y);
    }
}
