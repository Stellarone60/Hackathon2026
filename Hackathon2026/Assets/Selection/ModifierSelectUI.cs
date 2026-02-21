using System.Collections.Generic;
using UnityEngine;
using Assets.Modifiers;
public class ModifierSelectUI : MonoBehaviour
{
    //public PlayerInventory playerInventory;
    public GameObject modifierPrefab;
    public Transform contentParent;

    private List<ModifierBase> selectedItems = new List<ModifierBase>();

    void Start()
    {
        PopulateUI();
    }

    void PopulateUI()
    {
        // foreach (var item in playerInventory.items)
        // {
        //     GameObject obj = Instantiate(itemPrefab, contentParent);
        //     obj.GetComponent<InventoryItemUI>().Setup(item, this);
        // }
    }

    public void OnItemSelectionChanged(ModifierBase modifier, bool selected)
    {
        if (selected)
            selectedItems.Add(modifier);
        else
            selectedItems.Remove(modifier);

    }
}