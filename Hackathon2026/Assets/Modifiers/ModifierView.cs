using Assets.Modifiers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ModifierView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private GameObject highlight;
    [SerializeField] private Button button;

    private ModifierBase modifier;
    private ModifierDescriptionDisplay descriptionDisplay;

    private bool isSelected = false;

    public void Initialize(ModifierDescriptionDisplay descriptionDisplay)
    {
        this.descriptionDisplay = descriptionDisplay;
    }

    public void Bind(ModifierBase modifier)
    {
        this.modifier = modifier;
        nameText.text = modifier.modifierName;
        icon.sprite = modifier.modifierSprite;

        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        isSelected = !isSelected;
        highlight.SetActive(isSelected);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionDisplay.SetText("Temporary description");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionDisplay.SetText("");
    }
}