using UnityEngine;
using UnityEngine.UI;
using Assets.Modifiers;


public class ModifierUI : MonoBehaviour
{
    //public Image icon;
    //public Text nameText;
    public Image selectionHighlight;

    private ModifierBase modifier;

    private ModifierSelectUI inventoryUI;
    private bool isSelected = false;

    public void Setup(ModifierBase newModifier, ModifierSelectUI ui) // modifier UI
    {
        modifier = newModifier;
        inventoryUI = ui;
        //inventoryUI = ui;

        //nameText.text = modifier.modifierName;
        //icon.sprite = modifier.icon;

        UpdateVisual();
    }

    // void ToggleSelection()
    // {
    //     isSelected = !isSelected;
    //     //
    //     inventoryUI.OnModifierSelectionChanged(modifier, isSelected);
    //     UpdateVisual();
    // }

    void UpdateVisual()
    {
        selectionHighlight.enabled = isSelected;
    }
}