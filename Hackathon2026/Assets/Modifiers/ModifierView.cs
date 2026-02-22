using Assets.Modifiers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events; // Needed for UnityEvent
public class ModifierView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private GameObject highlight;
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text description;
    public UnityEvent<bool> OnSelectionChanged;

    private ModifierBase modifier;

    private bool isSelected = false;

    public bool IsSelected => isSelected;

    public void Bind(ModifierBase modifier)
    {
        this.modifier = modifier;
        nameText.text = modifier.modifierName;
        icon.sprite = modifier.modifierSprite;
        description.text = modifier.description;

        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        isSelected = !isSelected;
        highlight.SetActive(isSelected);
        Debug.Log("Clicked on modifier. Highlight set to active " + highlight.activeSelf);

        OnSelectionChanged?.Invoke(isSelected);
    }
}