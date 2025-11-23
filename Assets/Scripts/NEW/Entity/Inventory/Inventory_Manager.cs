using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Manager : MonoBehaviour
{
    [SerializeField] private GameObject PanelInventaire;
    [SerializeField] private GameObject PanelItem;

    [SerializeField] private TextMeshProUGUI nameTextMesh;
    [SerializeField] private TextMeshProUGUI descriptionTextMesh;

    [SerializeField] private List<Button> buttonsItems;


    //TEMPORAIRE
    [SerializeField] private ModificatorsMap modifMap;

    public bool InventoryActive => PanelInventaire.activeSelf == true;

    private int activeIndex = 999;

    public void OnClicEatButton()
    {
        if (modifMap.p.inventory[activeIndex] is IEatable e)
        {
            e.OnEat(modifMap.p);
            modifMap.p.inventory.RemoveAt(activeIndex);
            ReloadVisualsItems();
        }
    }
    public void OnClicThrowButton()
    {
        Debug.Log("throw");
    }
    public void OnClicDropButton()
    {
        //activeitem.Model.onDrop?.Invoke();
        bool b = modifMap.AddItemToMap(modifMap.p.inventory[activeIndex], modifMap.p.PosX, modifMap.p.PosY);
        if (b == true)
        { 
            modifMap.p.inventory.RemoveAt(activeIndex);
            ReloadVisualsItems();
        }
    }
    public void OnClicPlaceButton()
    {
    }

    public void OnClicPickupButton()
    {
        Items i = modifMap.RemoveItemAtPosition(modifMap.p.PosX, modifMap.p.PosY);
        Debug.Log(i);
        if (i != null)
        {
            modifMap.p.inventory.Add(i);
        }
        ReloadVisualsItems();
    }

    public void OnClicEquipButton()
    {
        if (modifMap.p.inventory[activeIndex] is IEquipable e) e.OnEquip();
    }

    public void PanelActivation()
    {
        if (PanelInventaire.activeSelf == true)
        {
            CloseAll();
        }
        else
        {
            SetButtons();
            PanelInventaire.SetActive(true);
        }
    }
    public void PanelItemActivation(int index)
    {
        if (PanelItem.activeSelf == true && index == activeIndex)
            PanelItem.SetActive(false);
        else
        {
            SetUIItem(index);
            PanelItem.SetActive(true);
            activeIndex = index;
        }
    }
    private void ClosePanelItem() => PanelItem.SetActive(false);

    public void SetUIItem(int i)
    {
        nameTextMesh.text = modifMap.p.inventory[i].ItemName;
        descriptionTextMesh.text = modifMap.p.inventory[i].Description;
    }

    private void SetButtons()
    {
        ResetButtons();
        for (int i = 0; i < modifMap.p.inventory.Count; i++)
        {
            buttonsItems[i].gameObject.SetActive(true);
            buttonsItems[i].image.sprite = modifMap.p.inventory[i].spriteUI;
        }
    }

    private void ResetButtons()
    {
        foreach (Button b in buttonsItems)
        { 
            b.image.sprite = null;
            b.gameObject.SetActive(false);
        }
    }

    private void ReloadVisualsItems()
    {
        SetButtons();
        ClosePanelItem();
    }

    public void CloseAll()
    {
        activeIndex = 999;
        PanelItem.SetActive(false);
        PanelInventaire.SetActive(false);
    }
}
