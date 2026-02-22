using System.Collections.Generic;
using UnityEngine;
using Assets.Modifiers;
public class ModifierSelectUI : MonoBehaviour
{
    public List<ModifierBase> playerInventory = new List<ModifierBase>();
    //public GameObject modifierPrefab;

    public GameObject inventory;
    public Transform contentParent;

    private List<ModifierBase> selectedItems = new List<ModifierBase>();

    void Start()
    {
        playerInventory.Add(new EnemySpeedModifier());
        playerInventory.Add(new AddTrapsRoomModifier());
        //PopulateUI();
    }

    void Update()
    {
        // For testing, print selected items.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.SetActive(true);
        }
    }

    public void AddModifier(string modifierName)
    {
        playerInventory.Add(new EnemySpeedModifier());
        //
    }
    // void PopulateUI()
    // {
    //     foreach (var item in playerInventory)
    //     {
    //         GameObject obj = Instantiate(modifierPrefab, contentParent);
    //         obj.GetComponent<ModifierUI>().Setup(item, this);
    //     }
    // }

    public void OnModifierSelectionChanged(ModifierBase modifier, bool selected)
    {
        if (selected)
            selectedItems.Add(modifier);
        else
            selectedItems.Remove(modifier);

    }
}