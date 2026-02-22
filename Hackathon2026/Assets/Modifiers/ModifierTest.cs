using Assets.Modifiers;
using UnityEngine;

public class ModifierViewTester : MonoBehaviour
{
    [SerializeField] private ModifierView modifierViewPrefab;
    [SerializeField] private Transform parent;   // UI parent under canvas
    [SerializeField] private ModifierDescriptionDisplay descriptionDisplay;


    private void Start()
    {
        StartCoroutine(SpawnAfterDelay());
    }

    private System.Collections.IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(5f);

        // Create a test modifier (backend)
        ModifierBase testModifier = new EnemyHealthModifier();

        // Spawn the UI prefab (frontend)
        ModifierView view = Instantiate(modifierViewPrefab, parent);

        // Initialize hover + selection logic
        view.Initialize(descriptionDisplay);


        Debug.Log("About to call bind");
        // Bind backend → frontend
        view.Bind(testModifier);
    }
}