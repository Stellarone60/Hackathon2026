using Assets.Modifiers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModifierView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text nameText;

    private ModifierBase modifier;

    public void Bind(ModifierBase modifier)
    {
        Debug.Log("In bind method");
        try
        {
            this.modifier = modifier;
            Debug.Log("About to bind text, modifier name is " + modifier.modifierName + "And name.text is " + nameText.text);

            nameText.text = modifier.modifierName;
            Debug.Log("Text bound, about to bind sprite");

            if(modifier.modifierSprite == null)
            {
                Debug.LogWarning("Modifier sprite is null for: " + modifier.modifierName);
                return;
            }

            icon.sprite = modifier.modifierSprite;
            Debug.Log("Successfully bound modifiers");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to bind modifier: " + e.Message);
        }
    }
}