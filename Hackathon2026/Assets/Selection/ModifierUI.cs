using UnityEngine;
using UnityEngine.UI;
using Assets.Modifiers;


public class ModifierUI : MonoBehaviour
{
    public Image icon;
    public Text nameText;
    public Image selectionHighlight;

    private ModifierBase modifier;
    //modifier UI goes here;
    private bool isSelected = false;

    public void Setup(ModifierBase newModifier) // modifier UI
    {
        modifier = newModifier;
        //inventoryUI = ui;

        nameText.text = modifier.modifierName;
        //icon.sprite = modifier.icon;

        GetComponent<Button>().onClick.AddListener(ToggleSelection);
        UpdateVisual();
    }

    void ToggleSelection()
    {
        isSelected = !isSelected;
        //inventoryUI.OnModifierSelectionChanged(modifier, isSelected);
        UpdateVisual();
    }

    void UpdateVisual()
    {
        selectionHighlight.enabled = isSelected;
    }
}