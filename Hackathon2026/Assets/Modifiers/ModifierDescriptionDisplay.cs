using TMPro;
using UnityEngine;

public class ModifierDescriptionDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text descriptionText;

    public void SetText(string text)
    {
        descriptionText.text = text;
    }
}