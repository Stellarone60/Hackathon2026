using System.Collections.Generic;
using UnityEngine;
using Assets.Modifiers;
using UnityEngine.UI;
public class ModifierSelectUI : MonoBehaviour
{
    public List<ModifierBase> playerInventory = new List<ModifierBase>();
    //public GameObject modifierPrefab;

    public GameObject inventory;

    public GameObject modifierPrefab;


    [SerializeField] private RectTransform contentParent;

    private List<ModifierBase> selectedItems = new List<ModifierBase>();

    void Start()
    {
        playerInventory.Add(new EnemySpeedModifier());
        playerInventory.Add(new EnemySpeedModifier());
        playerInventory.Add(new EnemySpeedModifier());
        ShowModifiers();
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
        // Should call factory to create this.
        playerInventory.Add(new EnemySpeedModifier());
        //
    }
    
    public void ShowModifiers()
    {
        gameObject.SetActive(true);

        foreach (var mod in playerInventory)
        {

            GameObject obj = Instantiate(modifierPrefab, contentParent);
            obj.GetComponent<ModifierView>().Bind(mod);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentParent);
        
    }

    public void OnModifierSelectionChanged(ModifierBase modifier, bool selected)
    {
        if (selected)
            selectedItems.Add(modifier);
        else
            selectedItems.Remove(modifier);

    }
}