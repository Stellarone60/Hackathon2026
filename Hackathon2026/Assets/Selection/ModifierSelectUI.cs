using System.Collections.Generic;
using UnityEngine;
using Assets.Modifiers;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using UnityEngine.Events; // Needed for UnityEvent
public class ModifierSelectUI : MonoBehaviour
{
    public List<ModifierBase> playerInventory = new List<ModifierBase>();
    //public GameObject modifierPrefab;

    public GameObject inventory;

    private bool isInventoryOpen = false;

    public GameObject modifierPrefab;
    


    [SerializeField] private RectTransform contentParent;

    private List<ModifierBase> selectedItems = new List<ModifierBase>();

    void Start()
    {
        playerInventory.Add(new EnemySpeedModifier());
        playerInventory.Add(new EnemySpeedModifier());
        playerInventory.Add(new EnemySpeedModifier());
        inventory.SetActive(isInventoryOpen);
        
        ShowModifiers();
        //PopulateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
    {
        
        isInventoryOpen = !isInventoryOpen;
        inventory.SetActive(isInventoryOpen);


    }
    }

    public void HandleButtonPress()
    {
        inventory.SetActive(false);
        // TODO: REcord the selections.
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
            ModifierView view = obj.GetComponent<ModifierView>();
            view.Bind(mod);
            view.OnSelectionChanged.AddListener((isSelected) => OnModifierSelectionChanged(mod, isSelected));

        }

        
    }

    public void OnModifierSelectionChanged(ModifierBase modifier, bool selected)
    {
        if (selected){
            selectedItems.Add(modifier);
            Debug.Log("Modifier " + modifier.modifierName + " selected: ");}
        else{
            selectedItems.Remove(modifier);
            Debug.Log("Modifier " + modifier.modifierName + " deselected: ");}

    }
}